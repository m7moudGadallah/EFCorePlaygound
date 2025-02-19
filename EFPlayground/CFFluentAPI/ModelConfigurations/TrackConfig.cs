using CFFluentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CFFluentAPI.ModelConfigurations;

public class TrackConfig : IEntityTypeConfiguration<Track>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(t => t.DepartmentId)
            .IsRequired();

        builder.HasOne(t => t.Department)
                .WithMany(d => d.Tracks)
                .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Courses)
            .WithMany(c => c.Tracks);

        builder.HasMany(t => t.Students)
            .WithOne(s => s.Track);
    }
}
