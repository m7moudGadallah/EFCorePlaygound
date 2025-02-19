using CFFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFFluentAPI.ModelConfigurations;

public class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasMany(d => d.Instructors)
                .WithOne(i => i.Department);

        builder.HasOne(d => d.HeadInstructor)
            .WithOne(i => i.ManagedDepartment)
            .HasForeignKey<Department>(d => d.HeadInstructorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(d => d.Tracks)
            .WithOne(t => t.Department);
    }
}

/*
 *     [Key]
    public int Id { get; set; }

    [NotNull]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [ForeignKey("HeadInstructor")]
    public int? HeadInstructorId { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    [InverseProperty("ManagedDepartment")]
    public virtual Instructor HeadInstructor { get; set; }

    [InverseProperty("Department")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public override string ToString()
    => $"Department {{Id = {Id}, Name = {Name}, HeadInstructorId = {HeadInstructorId}}}";*/
