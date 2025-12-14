using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class Team
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Season { get; set; } = null!;

    public string? Desc { get; set; }

    public string? TeamType { get; set; }

    public string? Status { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<TeamBird> TeamBirds { get; set; } = new List<TeamBird>();
}
