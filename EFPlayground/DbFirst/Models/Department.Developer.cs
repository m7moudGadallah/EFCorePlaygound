namespace DbFirst.Models;

public partial class Department
{
    public override string ToString()
        => $"Department {{Id = {Id}, Name = {Name}, HeadInstructorId = {HeadInstructorId}}}";
}
