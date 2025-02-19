using CFFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFFluentAPI.ModelConfigurations;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(s => s.TrackId)
            .IsRequired();

        builder.HasIndex(s => s.Email).IsUnique();

        builder.HasOne(s => s.Track)
            .WithMany(t => t.Students)
            .HasForeignKey(s => s.TrackId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
