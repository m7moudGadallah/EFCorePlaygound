namespace DbFirst.Models;

public partial class Course
{
    public override string ToString()
        => $"Course {{Id = {Id}, Tile = {Title}, CreditHours = {CreditHours}}}";
}
