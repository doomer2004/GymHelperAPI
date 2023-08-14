using GymHelper.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymHelper.DAL.EF;

public sealed class Context : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserSubscription> UserSubscriptions { get; set; } = null!;
    public DbSet<Subscription> Subscriptions { get; set; } = null!;
    
    
    public Context()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=GymAPI;Trusted_Connection=True;TrustServerCertificate=True");
    }
}