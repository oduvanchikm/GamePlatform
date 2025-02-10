using Microsoft.EntityFrameworkCore;
using GamePlatform.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamePlatform.DAL.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        
        builder.Property(u => u.Email)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.PasswordHash)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.UserName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.UserSurname)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(u => u.UserGenderId)
            .IsRequired();
        
        builder.Property(u => u.DateOfBirth)
            .IsRequired();
        
        builder.Property(u => u.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder.Property(u => u.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .IsRequired();
        
        builder.HasOne(x => x.Role)
            .WithMany(r => r.User)
            .HasForeignKey(x => x.RoleId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Gender)
            .WithMany(r => r.User)
            .HasForeignKey(x => x.UserGenderId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(gu => gu.GameUsers)
            .WithOne(gu => gu.User)
            .HasForeignKey(gu => gu.UserId);
    }
}