using System.Data;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Runtime.Versioning;

namespace RPMS_DB_Migration.Services
{
    [SupportedOSPlatform("windows")]
    public class MigrationService
    {
        private readonly string _accessConnStr;
        private readonly string _sqlConnStr;

        public MigrationService(IConfiguration config)
        //{
        // Read connection strings from appsettings.json
        //_accessConnStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={config["ConnectionStrings:AccessFile"]};";
        //_sqlConnStr = config.GetConnectionString("SqlServer");
        //}
       
        {
            var accessFile = config.GetConnectionString("AccessFile") ?? config["ConnectionStrings:AccessFile"];
            if (string.IsNullOrWhiteSpace(accessFile))
                throw new ArgumentException("Missing AccessFile path in configuration.", nameof(config));

            // Prefer ACE for 64-bit support; ensure Access Database Engine is installed on the host.
            _accessConnStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={accessFile};Persist Security Info=False;";

            _sqlConnStr = config.GetConnectionString("SqlServer")
                          ?? throw new ArgumentException("Missing SqlServer connection string.", nameof(config));
        }

        [SupportedOSPlatform("windows")]
        public async Task ExtractSchemaAsync()
        {
            using var accessConn = new OleDbConnection(_accessConnStr);
            await accessConn.OpenAsync();

            DataTable tables = accessConn.GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
            {
                string? tableNameObj = row["TABLE_NAME"] as string;
                string tableName = tableNameObj ?? string.Empty;
                if (tableName.StartsWith("MSys")) continue;

                DataTable columnsSchemaTable = accessConn.GetSchema("Columns", new[] { null, null, tableName });
                DataTable columns = columnsSchemaTable;

                var createSql = $"CREATE TABLE {tableName} (";
                foreach (DataRow col in columns.Rows)
                {
                    string? colNameObj = col["COLUMN_NAME"] as string;
                    string colName = colNameObj ?? string.Empty;
                    string? dataTypeObj = col["DATA_TYPE"]?.ToString();
                    string dataType = MapDataType(dataTypeObj ?? string.Empty);
                    createSql += $"{colName} {dataType},";
                }
                createSql = createSql.TrimEnd(',') + ")";

                using var sqlConn = new SqlConnection(_sqlConnStr);
                await sqlConn.OpenAsync();
                using var cmd = new SqlCommand(createSql, sqlConn);
                await cmd.ExecuteNonQueryAsync();
            }
        }

        [SupportedOSPlatform("windows")]
        public async Task MigrateDataAsync()
        {
            using var accessConn = new OleDbConnection(_accessConnStr);
            await accessConn.OpenAsync();

            DataTable tables = accessConn.GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
            {
                string? tableNameObj = row["TABLE_NAME"] as string;
                string tableName = tableNameObj ?? string.Empty;
                if (tableName.StartsWith("MSys")) continue;

                using var cmd = new OleDbCommand($"SELECT * FROM {tableName}", accessConn);
                using var reader = await cmd.ExecuteReaderAsync();

                using var bulkCopy = new SqlBulkCopy(_sqlConnStr)
                {
                    DestinationTableName = tableName
                };
                await bulkCopy.WriteToServerAsync(reader);
            }
        }

        public async Task AddIdsAsync()
        {
            using var sqlConn = new SqlConnection(_sqlConnStr);
            await sqlConn.OpenAsync();

            DataTable tables = sqlConn.GetSchema("Tables");

            foreach (DataRow row in tables.Rows)
            {
                string? tableNameObj = row["TABLE_NAME"] as string;
                string tableName = tableNameObj ?? string.Empty;
                if (tableName.StartsWith("sys")) continue;

                string alterSql = $"ALTER TABLE {tableName} ADD Id INT IDENTITY(1,1) PRIMARY KEY";
                using var cmd = new SqlCommand(alterSql, sqlConn);
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch
                {
                    // Ignore if already has PK
                }
            }
        }

        private static string MapDataType(string accessType)
        {
            return accessType switch
            {
                "3" => "INT",             // Long
                "202" => "NVARCHAR(255)", // Text
                "7" => "DATETIME",        // Date/Time
                _ => "NVARCHAR(255)"
            };
        }
    }
}

