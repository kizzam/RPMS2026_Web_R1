using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class Pen
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Desc { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Bird> Birds { get; set; } = new List<Bird>();
}
