using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RPMS2026_Web_R1.Data;

public partial class Rpms2026WebContext : DbContext
{
    public Rpms2026WebContext()
    {
    }

    public Rpms2026WebContext(DbContextOptions<Rpms2026WebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Bird> Birds { get; set; }

    public virtual DbSet<Bloodline> Bloodlines { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    public virtual DbSet<EyeSign> EyeSigns { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Pen> Pens { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamBird> TeamBirds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RPMS2026_Web;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubNetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audit>(entity =>
        {
            entity.ToTable("Audit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ActionType).HasMaxLength(10);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.RecordId).HasColumnName("RecordID");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
            entity.Property(e => e.TableName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Bird>(entity =>
        {
            entity.ToTable("Bird", tb => tb.HasTrigger("TRG_Bird_Audit"));

            entity.HasIndex(e => e.IdBloodline, "IX_Bird_ID_BloodLine");

            entity.HasIndex(e => e.IdColour, "IX_Bird_ID_Colour");

            entity.HasIndex(e => e.IdEyeSign, "IX_Bird_ID_EyeSign");

            entity.HasIndex(e => e.IdGender, "IX_Bird_ID_Gender");

            entity.HasIndex(e => e.IdPen, "IX_Bird_ID_Pen");

            entity.HasIndex(e => e.IdRating, "IX_Bird_ID_Rating");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AquireDesc).HasMaxLength(50);
            entity.Property(e => e.AquireValue).HasColumnType("money");
            entity.Property(e => e.Birdname)
                .HasMaxLength(16)
                .HasColumnName("birdname");
            entity.Property(e => e.Bloodline)
                .HasMaxLength(26)
                .HasColumnName("bloodline");
            entity.Property(e => e.Bredby)
                .HasMaxLength(24)
                .HasColumnName("bredby");
            entity.Property(e => e.Bredfor)
                .HasMaxLength(24)
                .HasColumnName("bredfor");
            entity.Property(e => e.DDob)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("dDOB");
            entity.Property(e => e.Dammark)
                .HasMaxLength(12)
                .HasColumnName("dammark");
            entity.Property(e => e.Damringno)
                .HasMaxLength(8)
                .HasColumnName("damringno");
            entity.Property(e => e.Damyr).HasColumnName("damyr");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DisDesc).HasMaxLength(50);
            entity.Property(e => e.DisValue).HasColumnType("money");
            entity.Property(e => e.IdBloodline).HasColumnName("ID_Bloodline");
            entity.Property(e => e.IdColour).HasColumnName("ID_Colour");
            entity.Property(e => e.IdDam).HasColumnName("ID_Dam");
            entity.Property(e => e.IdEyeSign).HasColumnName("ID_EyeSign");
            entity.Property(e => e.IdGender).HasColumnName("ID_Gender");
            entity.Property(e => e.IdPen).HasColumnName("ID_Pen");
            entity.Property(e => e.IdRating).HasColumnName("ID_Rating");
            entity.Property(e => e.IdSire).HasColumnName("ID_Sire");
            entity.Property(e => e.IndBredSnglPen).HasColumnName("indBredSnglPen");
            entity.Property(e => e.IndDnacert).HasColumnName("indDNACert");
            entity.Property(e => e.IndImport)
                .HasMaxLength(1)
                .HasColumnName("indImport");
            entity.Property(e => e.IndPedgOnly).HasColumnName("indPedgOnly");
            entity.Property(e => e.IndThroat)
                .HasMaxLength(1)
                .HasColumnName("indThroat");
            entity.Property(e => e.Indbpa).HasColumnName("indbpa");
            entity.Property(e => e.Indbpb).HasColumnName("indbpb");
            entity.Property(e => e.Indbredforstock).HasColumnName("indbredforstock");
            entity.Property(e => e.Indrace).HasColumnName("indrace");
            entity.Property(e => e.Indref).HasColumnName("indref");
            entity.Property(e => e.Indsoh).HasColumnName("indsoh");
            entity.Property(e => e.Indsp1).HasColumnName("indsp1");
            entity.Property(e => e.Indsp2).HasColumnName("indsp2");
            entity.Property(e => e.Indstatus).HasColumnName("indstatus");
            entity.Property(e => e.Indstock).HasColumnName("indstock");
            entity.Property(e => e.Mark)
                .HasMaxLength(12)
                .HasColumnName("mark");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Ringno)
                .HasMaxLength(8)
                .HasColumnName("ringno");
            entity.Property(e => e.SeqList).HasColumnName("Seq_List");
            entity.Property(e => e.Siremark)
                .HasMaxLength(12)
                .HasColumnName("siremark");
            entity.Property(e => e.Sireringno)
                .HasMaxLength(8)
                .HasColumnName("sireringno");
            entity.Property(e => e.Sireyr).HasColumnName("sireyr");
            entity.Property(e => e.Yr).HasColumnName("yr");

            entity.HasOne(d => d.IdBloodlineNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdBloodline)
                .HasConstraintName("FK_Bird_BloodLine");

            entity.HasOne(d => d.IdColourNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdColour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bird_Colour");

            entity.HasOne(d => d.IdEyeSignNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdEyeSign)
                .HasConstraintName("FK_Bird_EyeSign");

            entity.HasOne(d => d.IdGenderNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdGender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Bird_Gender");

            entity.HasOne(d => d.IdPenNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdPen)
                .HasConstraintName("FK_Bird_Pen");

            entity.HasOne(d => d.IdRatingNavigation).WithMany(p => p.Birds)
                .HasForeignKey(d => d.IdRating)
                .HasConstraintName("FK_Bird_Rating");
        });

        modelBuilder.Entity<Bloodline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_BloodLine");

            entity.ToTable("Bloodline", tb => tb.HasTrigger("TRG_BloodLine_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
            entity.Property(e => e.Type).HasMaxLength(12);
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.ToTable("Colour", tb => tb.HasTrigger("TRG_Colour_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
        });

        modelBuilder.Entity<EyeSign>(entity =>
        {
            entity.ToTable("EyeSign", tb => tb.HasTrigger("TRG_EyeSign_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BestMatingCode).HasMaxLength(5);
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.ToTable("Gender", tb => tb.HasTrigger("TRG_Gender_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.ToTable("Note");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdBird).HasColumnName("ID_Bird");
            entity.Property(e => e.NoteDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.NoteType)
                .HasMaxLength(1)
                .HasDefaultValue("G");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
        });

        modelBuilder.Entity<Pen>(entity =>
        {
            entity.ToTable("Pen", tb => tb.HasTrigger("TRG_Pen_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.ToTable("Rating", tb => tb.HasTrigger("TRG_Rating_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Level).HasDefaultValue(0);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
            entity.Property(e => e.System).HasDefaultValue(true);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team", tb => tb.HasTrigger("TRG_Team_Audit"));

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Season).HasMaxLength(5);
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
            entity.Property(e => e.TeamType)
                .HasMaxLength(1)
                .HasDefaultValue("G");
        });

        modelBuilder.Entity<TeamBird>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeamBird__3214EC2754C280C8");

            entity.ToTable("TeamBird", tb => tb.HasTrigger("TRG_TeamBird_Audit"));

            entity.HasIndex(e => new { e.IdBird, e.IdTeam }, "UQ_TeamBird").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(5);
            entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IdBird).HasColumnName("ID_Bird");
            entity.Property(e => e.IdTeam).HasColumnName("ID_Team");
            entity.Property(e => e.Mark)
                .HasMaxLength(12)
                .HasColumnName("mark");
            entity.Property(e => e.Ringno)
                .HasMaxLength(8)
                .HasColumnName("ringno");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .HasDefaultValue("A");
            entity.Property(e => e.Yr).HasColumnName("yr");

            entity.HasOne(d => d.IdTeamNavigation).WithMany(p => p.TeamBirds)
                .HasForeignKey(d => d.IdTeam)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TeamBird_Team");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
