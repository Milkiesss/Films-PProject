using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class UserActorConfiguration : IEntityTypeConfiguration<UserActors>
{
    public void Configure(EntityTypeBuilder<UserActors> builder)
    {
        builder.HasKey(ua => new { ua.UserId, ua.ActorId });
        builder.HasOne(ua => ua.User)
            .WithMany(p => p.Actors)
            .HasForeignKey(ua => ua.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(ua => ua.Actor)
            .WithMany()
            .HasForeignKey(ua => ua.ActorId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}