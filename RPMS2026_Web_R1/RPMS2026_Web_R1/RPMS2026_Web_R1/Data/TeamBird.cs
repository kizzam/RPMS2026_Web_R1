using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class TeamBird
{
    public int Id { get; set; }

    public int IdTeam { get; set; }

    public int IdBird { get; set; }

    public string Code { get; set; } = null!;

    public int Yr { get; set; }

    public string Mark { get; set; } = null!;

    public string Ringno { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Team IdTeamNavigation { get; set; } = null!;
}
