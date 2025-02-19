using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CFFluentAPI.Models;

public class Instructor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;


    public string Email { get; set; } = null!;

    public int? SupervisorId { get; set; }


    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; }


    public virtual Department ManagedDepartment { get; set; }

    public virtual Instructor Supervisor { get; set; }

    public virtual ICollection<Instructor> SupervisiedInstructors { get; set; } = new List<Instructor>();

    public override string ToString()
        => $"Instructor {{Id = {Id}, Name = {Name}, Email = {Email}, SupervisorId = {SupervisorId}, DepartmentId = {DepartmentId}}}";
}
