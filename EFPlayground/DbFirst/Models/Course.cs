using System;
using System.Collections.Generic;

namespace DbFirst.Models;

public partial class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CreditHours { get; set; }

    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();
}
