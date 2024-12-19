using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Description)
            .IsRequired();
        builder.HasMany(m => m.MovieActors)
            .WithOne(ma => ma.Movie)
            .HasForeignKey(ma => ma.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.AwardsCollection)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}