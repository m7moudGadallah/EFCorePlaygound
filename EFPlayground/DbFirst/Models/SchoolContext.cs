using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirst.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Courses__3214EC07027F98FE");

            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07AD59AC7E");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.HeadInstructor).WithMany(p => p.Departments)
                .HasForeignKey(d => d.HeadInstructorId)
                .HasConstraintName("FK_HeadInstructor");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Instruct__3214EC076D5A1A0F");

            entity.HasIndex(e => e.Email, "UQ__Instruct__A9D10534FFB1FE50").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Instructors)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Instructo__Depar__4D94879B");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.InverseSupervisor)
                .HasForeignKey(d => d.SupervisorId)
                .HasConstraintName("FK__Instructo__Super__4CA06362");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0708B301BB");

            entity.HasIndex(e => e.Email, "UQ__Students__A9D105344B6AF519").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Track).WithMany(p => p.Students)
                .HasForeignKey(d => d.TrackId)
                .HasConstraintName("FK__Students__TrackI__5535A963");
        });

        modelBuilder.Entity<Track>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tracks__3214EC070940323B");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Tracks)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Tracks__Departme__5165187F");

            entity.HasMany(d => d.Courses).WithMany(p => p.Tracks)
                .UsingEntity<Dictionary<string, object>>(
                    "TrackCourse",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK__TrackCour__Cours__5AEE82B9"),
                    l => l.HasOne<Track>().WithMany()
                        .HasForeignKey("TrackId")
                        .HasConstraintName("FK__TrackCour__Track__59FA5E80"),
                    j =>
                    {
                        j.HasKey("TrackId", "CourseId").HasName("PK__TrackCou__16E62FFA17A4F368");
                        j.ToTable("TrackCourses");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
