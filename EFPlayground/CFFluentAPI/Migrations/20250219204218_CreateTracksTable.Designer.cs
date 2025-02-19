﻿// <auto-generated />
using CFFluentAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CFFluentAPI.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20250219204218_CreateTracksTable")]
    partial class CreateTracksTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CFFluentAPI.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HeadInstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("HeadInstructorId")
                        .IsUnique()
                        .HasFilter("[HeadInstructorId] IS NOT NULL");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("SupervisorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SupervisorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Track", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CourseTrack", b =>
                {
                    b.Property<int>("CoursesId")
                        .HasColumnType("int");

                    b.Property<int>("TracksId")
                        .HasColumnType("int");

                    b.HasKey("CoursesId", "TracksId");

                    b.HasIndex("TracksId");

                    b.ToTable("CourseTrack");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Department", b =>
                {
                    b.HasOne("CFFluentAPI.Models.Instructor", "HeadInstructor")
                        .WithOne("ManagedDepartment")
                        .HasForeignKey("CFFluentAPI.Models.Department", "HeadInstructorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("HeadInstructor");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Instructor", b =>
                {
                    b.HasOne("CFFluentAPI.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CFFluentAPI.Models.Instructor", "Supervisor")
                        .WithMany("SupervisiedInstructors")
                        .HasForeignKey("SupervisorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Department");

                    b.Navigation("Supervisor");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Track", b =>
                {
                    b.HasOne("CFFluentAPI.Models.Department", "Department")
                        .WithMany("Tracks")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("CourseTrack", b =>
                {
                    b.HasOne("CFFluentAPI.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CFFluentAPI.Models.Track", null)
                        .WithMany()
                        .HasForeignKey("TracksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CFFluentAPI.Models.Department", b =>
                {
                    b.Navigation("Instructors");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("CFFluentAPI.Models.Instructor", b =>
                {
                    b.Navigation("ManagedDepartment");

                    b.Navigation("SupervisiedInstructors");
                });
#pragma warning restore 612, 618
        }
    }
}
