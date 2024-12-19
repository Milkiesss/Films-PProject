using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Role).IsRequired();
        builder.OwnsOne(s => s.FullName, fullName =>
        {
            fullName.Property(f => f.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            fullName.Property(f => f.LastName)
                .IsRequired()
                .HasMaxLength(20);

        });
        
        builder.HasMany(p=>p.Movies)
            .WithOne(m=>m.User)
            .HasForeignKey(m=>m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(p=>p.Actors)
            .WithOne(m=>m.User)
            .HasForeignKey(m=>m.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}