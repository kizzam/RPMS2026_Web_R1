using System.Data;
using System.Data.OleDb;
using Microsoft.Extensions.Configuration;
using System.Runtime.Versioning;

namespace RPMS_DB_Migration.Services
{
    [SupportedOSPlatform("windows")]
    public class AccessReaderService
    {
        private readonly string _accessConnStr;

        public AccessReaderService(IConfiguration config)
        {
            // Connection string from appsettings.json
            var filePath = config["ConnectionStrings:AccessFile"];
            _accessConnStr = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};";
        }

        [SupportedOSPlatform("windows")]
        public async Task<List<string>> GetTablesAsync()
        {
            var tables = new List<string>();

            using var conn = new OleDbConnection(_accessConnStr);
            await conn.OpenAsync();

            DataTable schema = conn.GetSchema("Tables");
            foreach (DataRow row in schema.Rows)
            {
                var tableNameObj = row["TABLE_NAME"];
                if (tableNameObj is string tableName && !tableName.StartsWith("MSys"))
                {
                    tables.Add(tableName);
                }
            }

            return tables;
        }
    }
}

