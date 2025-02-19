using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CFDataAnnotations.Models;

public class Instructor
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
