using GamePlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamePlatform.DAL.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.RoleId);

        builder.Property(r => r.RoleId)
            .IsRequired();
        
        builder.HasMany(x => x.User)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
    }
}