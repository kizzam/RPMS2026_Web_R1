using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class Bird
{
    public int Id { get; set; }

    public int Yr { get; set; }

    public string Mark { get; set; } = null!;

    public string Ringno { get; set; } = null!;

    public string? Birdname { get; set; }

    public DateTime? DDob { get; set; }

    public string? Bredby { get; set; }

    public string? Bredfor { get; set; }

    public string? Bloodline { get; set; }

    public bool? Indstock { get; set; }

    public bool? Indrace { get; set; }

    public bool? Indsoh { get; set; }

    public bool? Indref { get; set; }

    public bool? Indbpa { get; set; }

    public bool? Indbpb { get; set; }

    public bool? Indsp1 { get; set; }

    public bool? Indsp2 { get; set; }

    public bool? Indstatus { get; set; }

    public bool? Indbredforstock { get; set; }

    public bool? IndDnacert { get; set; }

    public bool? IndBredSnglPen { get; set; }

    public bool? IndPedgOnly { get; set; }

    public string? IndThroat { get; set; }

    public string? IndImport { get; set; }

    public string? Notes { get; set; }

    public DateTime? AquireDate { get; set; }

    public decimal? AquireValue { get; set; }

    public string? AquireDesc { get; set; }

    public DateTime? DisDate { get; set; }

    public decimal? DisValue { get; set; }

    public string? DisDesc { get; set; }

    public int? SeqList { get; set; }

    public int? IdSire { get; set; }

    public int? Sireyr { get; set; }

    public string? Siremark { get; set; }

    public string? Sireringno { get; set; }

    public int? IdDam { get; set; }

    public int? Damyr { get; set; }

    public string? Dammark { get; set; }

    public string? Damringno { get; set; }

    public int IdColour { get; set; }

    public int? IdEyeSign { get; set; }

    public int? IdBloodline { get; set; }

    public int IdGender { get; set; }

    public int? IdPen { get; set; }

    public int? IdRating { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual Bloodline? IdBloodlineNavigation { get; set; }

    public virtual Colour IdColourNavigation { get; set; } = null!;

    public virtual EyeSign? IdEyeSignNavigation { get; set; }

    public virtual Gender IdGenderNavigation { get; set; } = null!;

    public virtual Pen? IdPenNavigation { get; set; }

    public virtual Rating? IdRatingNavigation { get; set; }
}
