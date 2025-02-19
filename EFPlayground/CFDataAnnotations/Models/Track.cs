using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDataAnnotations.Models;

public class Track
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [ForeignKey("Department")]
    public int DepartmentId { get; set; }

    [InverseProperty("Tracks")]
    public virtual Department Department { get; set; } = null!;

    [InverseProperty("Track")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    [InverseProperty("Tracks")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public override string ToString() => $"Track {{Id = {Id}, Name = {Name}, DepartmentId = {DepartmentId}}}";
}
