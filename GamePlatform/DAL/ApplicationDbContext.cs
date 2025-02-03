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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new GenderConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}