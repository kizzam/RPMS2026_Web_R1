namespace RPMS2026_Web_R1.DTOs
{
    public class BloodlineDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
    }

    public class Bloodline_ALLDTO
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Desc { get; set; } = string.Empty;
        public string? Type { get; set; }
        public string? Status { get; set; }
        public int BirdCount { get; set; }
    }
}
