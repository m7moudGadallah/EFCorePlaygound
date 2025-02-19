using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CFDataAnnotations.Models;

public class Course
{
    [Key]
    public int Id { get; set; }

    [NotNull]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [NotNull]
    public int CreditHours { get; set; }

    [InverseProperty("Courses")]
    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public override string ToString()
    => $"Course {{Id = {Id}, Tile = {Title}, CreditHours = {CreditHours}}}";
}
