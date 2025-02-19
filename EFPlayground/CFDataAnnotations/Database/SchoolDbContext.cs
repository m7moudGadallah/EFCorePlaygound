using CFDataAnnotations.Models;
using Config;
using Microsoft.EntityFrameworkCore;

namespace CFDataAnnotations.Database;

public class SchoolDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(AppConfig.ConnectionString);
}
