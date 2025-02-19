using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Track
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
