using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CFDataAnnotations.Models;

public class Department
{
    [Key]
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
    => $"Department {{Id = {Id}, Name = {Name}, HeadInstructorId = {HeadInstructorId}}}";
}
