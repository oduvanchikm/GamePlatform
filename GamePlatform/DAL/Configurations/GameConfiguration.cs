using Microsoft.EntityFrameworkCore;
using GamePlatform.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamePlatform.DAL.Configurations;

public class GameConfiguration : IEntityTypeConfiguration<Game>
{
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        builder.HasKey(g => g.GameId);

        builder.Property(g => g.GameName)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(g => g.GameDescription)
            .HasMaxLength(1000)
            .IsRequired();
        
        builder.HasMany(gu => gu.GameUsers)
            .WithOne(gu => gu.Game)
            .HasForeignKey(gu => gu.GameId);
    }
}