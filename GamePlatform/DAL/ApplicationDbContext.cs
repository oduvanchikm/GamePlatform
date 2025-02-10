using Microsoft.EntityFrameworkCore;
using GamePlatform.Models;
using GamePlatform.DAL.Configurations;

namespace GamePlatform.DAL;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<Gender> Gender { get; set; }
    public DbSet<Game> Game { get; set; }
    public DbSet<GameUsers> GameUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new GenderConfiguration());
        modelBuilder.ApplyConfiguration(new GameConfiguration());
        modelBuilder.ApplyConfiguration(new GameUsersConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}