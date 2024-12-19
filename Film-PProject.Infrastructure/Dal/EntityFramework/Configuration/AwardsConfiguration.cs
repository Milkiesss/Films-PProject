using Films_PProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Film_PProject.Infrastructure.Dal.EntityFramework.Configuration;

public class AwardsConfiguration : IEntityTypeConfiguration<Award>
{
    public void Configure(EntityTypeBuilder<Award> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name)
            .IsRequired();
        builder.Property(a => a.Reason)
            .IsRequired();
    }
}