using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CFFluentAPI.Models;

public class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? HeadInstructorId { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual Instructor HeadInstructor { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public override string ToString()
    => $"Department {{Id = {Id}, Name = {Name}, HeadInstructorId = {HeadInstructorId}}}";
}
