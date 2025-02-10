using Microsoft.EntityFrameworkCore;
using GamePlatform.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamePlatform.DAL.Configurations;

public class GameUsersConfiguration : IEntityTypeConfiguration<GameUsers>
{
    public void Configure(EntityTypeBuilder<GameUsers> builder)
    {
        builder.HasKey(gm => new
        {
            gm.UserId, gm.GameId
        });

        builder.Property(s => s.StartTime)
            .IsRequired();
        
        builder.Property(s => s.EndTime)
            .IsRequired();
    }
}