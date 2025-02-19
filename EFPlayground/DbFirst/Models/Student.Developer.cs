namespace DbFirst.Models;

public partial class Student
{
    public override string ToString()
        => $"Student {{Id = {Id}, Name = {Name}, Email = {Email}, TrackId = {TrackId}}}";
}
