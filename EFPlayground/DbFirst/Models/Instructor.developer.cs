namespace DbFirst.Models;

public partial class Instructor
{
    public override string ToString()
            => $"Instructor {{Id = {Id}, Name = {Name}, Email = {Email}, SupervisorId = {SupervisorId}, DepartmentId = {DepartmentId}}}";
}
