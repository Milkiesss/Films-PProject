using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class ActorConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.OwnsOne(s => s.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            fullName.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(20);

        });
        builder.Property(a => a.PlaceOfBirth)
            .IsRequired();
        builder.HasMany(a => a.MovieActors)
            .WithOne(ma => ma.Actor)
            .HasForeignKey(ma => ma.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(a => a.AwardsCollection)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}