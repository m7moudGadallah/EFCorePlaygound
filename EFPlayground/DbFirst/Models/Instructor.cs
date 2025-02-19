using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? SupervisorId { get; set; }

    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Instructor> InverseSupervisor { get; set; } = new List<Instructor>();

    public virtual Instructor? Supervisor { get; set; }
}
