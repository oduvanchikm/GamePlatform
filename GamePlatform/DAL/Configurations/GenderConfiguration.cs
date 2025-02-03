using GamePlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamePlatform.DAL.Configurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.HasKey(r => r.GenderId);

        builder.Property(r => r.NameGender)
            .HasMaxLength(20)
            .IsRequired();
        
        builder.HasMany(x => x.User)
            .WithOne(u => u.Gender)
            .HasForeignKey(u => u.UserGenderId);
    }
}