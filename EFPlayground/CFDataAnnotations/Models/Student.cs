using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CFDataAnnotations.Models;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [ForeignKey("Track")]
    public int TrackId { get; set; }

    [InverseProperty("Students")]
    public virtual Track Track { get; set; }

    public override string ToString()
    => $"Student {{Id = {Id}, Name = {Name}, Email = {Email}, TrackId = {TrackId}}}";
}
