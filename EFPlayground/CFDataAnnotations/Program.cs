// See https://aka.ms/new-console-template for more information
using CFDataAnnotations.Database;
using CFDataAnnotations.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


using (var dbContext = new SchoolDbContext())
{
    var students = dbContext.Students.ToList();

    foreach (var std in students)
    {
        Console.WriteLine(std);
    }

    Console.WriteLine("\n===================================\n");

    var instructors = dbContext.Instructors.Include(i => i.Department).ToList();
    foreach (var instructor in instructors)
    {
        Console.WriteLine(instructor);
        Console.WriteLine($"\t{instructor.Department}");
    }

    Console.WriteLine("\n===================================\n");

    var tracks = dbContext.Tracks.Include(t => t.Courses).ToList();

    foreach (var track in tracks)
    {
        Console.WriteLine(track);
        Console.WriteLine("\tCourses:");
        foreach (var course in track.Courses)
        {
            Console.WriteLine($"\t{course}");
        }
    }
}
