namespace CFFluentAPI.Models;

public class Track
{
    public int Id { get; set; }

    public string Name { get; set; }


    public int DepartmentId { get; set; }

    public virtual Department Department { get; set; }


    public virtual ICollection<Student> Students { get; set; } = new List<Student>();


    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public override string ToString() => $"Track {{Id = {Id}, Name = {Name}, DepartmentId = {DepartmentId}}}";
}
