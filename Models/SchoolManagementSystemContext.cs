using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Models;

public partial class SchoolManagementSystemContext : DbContext
{
    public SchoolManagementSystemContext()
    {
    }

    public SchoolManagementSystemContext(DbContextOptions<SchoolManagementSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassSubject> ClassSubjects { get; set; }

    public virtual DbSet<ClassWiseStudent> ClassWiseStudents { get; set; }

    public virtual DbSet<FacultySubject> FacultySubjects { get; set; }

    public virtual DbSet<MasterClass> MasterClasses { get; set; }

    public virtual DbSet<School> Schools { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Timetable> Timetables { get; set; }

    public virtual DbSet<Trust> Trusts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=PATELBALKRUSHNA\\SQLEXPRESS; database=School_Management_System; trusted_connection=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C6ED0F0D0");

            entity.ToTable("Attendance");

            entity.Property(e => e.Status).HasMaxLength(10);

            entity.HasOne(d => d.Student).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__Attendanc__Stude__693CA210");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Classes__CB1927C006D2867A");

            entity.Property(e => e.Section).HasMaxLength(10);

            entity.HasOne(d => d.MasterClass).WithMany(p => p.Classes)
                .HasForeignKey(d => d.MasterClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Classes__MasterC__4F7CD00D");
        });

        modelBuilder.Entity<ClassSubject>(entity =>
        {
            entity.HasKey(e => e.ClassSubjectId).HasName("PK__ClassSub__79A97359057D9C18");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSubj__Class__5DCAEF64");

            entity.HasOne(d => d.Subject).WithMany(p => p.ClassSubjects)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClassSubj__Subje__5EBF139D");
        });

        modelBuilder.Entity<ClassWiseStudent>(entity =>
        {
            entity.HasKey(e => e.ClassWiseStudentId).HasName("PK__ClassWis__3214EC074946B936");

            entity.ToTable("ClassWiseStudent");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassWiseStudents)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__ClassWise__Class__656C112C");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassWiseStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__ClassWise__Stude__66603565");
        });

        modelBuilder.Entity<FacultySubject>(entity =>
        {
            entity.HasKey(e => e.FacultySubjectId).HasName("PK__FacultyS__43741863E3C68F54");

            entity.HasOne(d => d.Staff).WithMany(p => p.FacultySubjects)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__FacultySu__Staff__619B8048");

            entity.HasOne(d => d.Subject).WithMany(p => p.FacultySubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__FacultySu__Subje__628FA481");
        });

        modelBuilder.Entity<MasterClass>(entity =>
        {
            entity.HasKey(e => e.MasterClassId).HasName("PK__MasterCl__4E194D565B451616");

            entity.Property(e => e.ClassName).HasMaxLength(50);
        });

        modelBuilder.Entity<School>(entity =>
        {
            entity.HasKey(e => e.SchoolId).HasName("PK__Schools__3DA4675B4635F530");

            entity.Property(e => e.SchoolName).HasMaxLength(100);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB17C9813483");

            entity.Property(e => e.Designation).HasMaxLength(100);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Doj).HasColumnName("DOJ");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52B99B93F2E74");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Dob).HasColumnName("DOB");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Students__ClassI__59063A47");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subjects__AC1BA3A838A9A6F0");

            entity.Property(e => e.SubjectName).HasMaxLength(100);
        });

        modelBuilder.Entity<Timetable>(entity =>
        {
            entity.HasKey(e => e.TimetableId).HasName("PK__Timetabl__68413F6023F288CC");

            entity.ToTable("Timetable");

            entity.Property(e => e.DayOfWeek).HasMaxLength(10);
            entity.Property(e => e.Period).HasMaxLength(10);

            entity.HasOne(d => d.Class).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__Timetable__Class__6C190EBB");

            entity.HasOne(d => d.Staff).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Timetable__Staff__6E01572D");

            entity.HasOne(d => d.Subject).WithMany(p => p.Timetables)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Timetable__Subje__6D0D32F4");
        });

        modelBuilder.Entity<Trust>(entity =>
        {
            entity.HasKey(e => e.TrustId).HasName("PK__Trust__A8BC6F117FAFA5C1");

            entity.ToTable("Trust");

            entity.Property(e => e.TrustName).HasMaxLength(100);
            entity.Property(e => e.TrusteeName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C97E4C3E0");

            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
