using CFFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFFluentAPI.ModelConfigurations;

public class InstructorConfig : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.HasKey(i => i.Id);

        builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(i => i.Email)
            .IsUnique();

        builder.Property(i => i.DepartmentId)
            .IsRequired();

        builder.HasOne(i => i.Supervisor)
               .WithMany(i => i.SupervisiedInstructors)
               .HasForeignKey(i => i.SupervisorId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i => i.Department)
            .WithMany(d => d.Instructors)
            .HasForeignKey(i => i.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(i => i.ManagedDepartment)
            .WithOne(d => d.HeadInstructor);
    }
}

/**
 * public class Instructor
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [ForeignKey("Supervisor")]
    public int? SupervisorId { get; set; }


    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    [InverseProperty("Instructors")]
    public virtual Department Department { get; set; }


    [InverseProperty("HeadInstructor")]
    public virtual Department ManagedDepartment { get; set; }

    [InverseProperty("SupervisiedInstructors")]
    public virtual Instructor Supervisor { get; set; }

    [InverseProperty("Supervisor")]
    public virtual ICollection<Instructor> SupervisiedInstructors { get; set; } = new List<Instructor>();

    public override string ToString()
        => $"Instructor {{Id = {Id}, Name = {Name}, Email = {Email}, SupervisorId = {SupervisorId}, DepartmentId = {DepartmentId}}}";
}
*/
