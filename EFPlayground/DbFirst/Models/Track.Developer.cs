namespace DbFirst.Models;

public partial class Track
{
    public override string ToString() => $"Track {{Id = {Id}, Name = {Name}, DepartmentId = {DepartmentId}}}";
}
