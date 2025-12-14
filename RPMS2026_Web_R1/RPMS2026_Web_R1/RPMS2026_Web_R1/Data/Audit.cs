using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class Audit
{
    public int Id { get; set; }

    public string TableName { get; set; } = null!;

    public string ActionType { get; set; } = null!;

    public int RecordId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? UserName { get; set; }

    public string? Status { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateCreated { get; set; }
}
