using CFFluentAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CFFluentAPI.ModelConfigurations;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(100);

        builder.Property(c => c.CreditHours)
                .IsRequired();
    }
}
