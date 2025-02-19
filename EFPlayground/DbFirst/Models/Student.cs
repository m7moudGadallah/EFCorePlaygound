using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int TrackId { get; set; }

    public virtual Track Track { get; set; } = null!;
}
