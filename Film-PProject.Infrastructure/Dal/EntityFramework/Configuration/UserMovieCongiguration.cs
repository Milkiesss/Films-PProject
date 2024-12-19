using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class UserMovieCongiguration : IEntityTypeConfiguration<UserMovies>
{
    public void Configure(EntityTypeBuilder<UserMovies> builder)
    {
        builder.HasKey(um => new { um.UserId, um.MovieId });
        builder.HasOne(um => um.User)
            .WithMany(p => p.Movies)
            .HasForeignKey(um => um.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(um => um.Movie)
            .WithMany()
            .HasForeignKey(um => um.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}