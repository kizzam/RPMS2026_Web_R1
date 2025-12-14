using System;
using System.Collections.Generic;

namespace RPMS2026_Web_R1.Data;

public partial class Note
{
    public int Id { get; set; }

    public int? IdBird { get; set; }

    public string? NoteType { get; set; }

    public DateTime NoteDate { get; set; }

    public string? NoteText { get; set; }

    public string? Status { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime DateCreated { get; set; }
}
