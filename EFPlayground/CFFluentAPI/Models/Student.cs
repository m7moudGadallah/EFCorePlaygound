namespace CFFluentAPI.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int TrackId { get; set; }
    public virtual Track Track { get; set; }

    public override string ToString()
    => $"Student {{Id = {Id}, Name = {Name}, Email = {Email}, TrackId = {TrackId}}}";
}
