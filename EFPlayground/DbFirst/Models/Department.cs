using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? HeadInstructorId { get; set; }

    public virtual Instructor? HeadInstructor { get; set; }

    public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
