using System.Diagnostics.CodeAnalysis;

namespace CFFluentAPI.Models;

public class Course
{

    public int Id { get; set; }


    public string Title { get; set; } = null!;


    public int CreditHours { get; set; }


    public virtual ICollection<Track> Tracks { get; set; } = new List<Track>();

    public override string ToString()
    => $"Course {{Id = {Id}, Tile = {Title}, CreditHours = {CreditHours}}}";
}
