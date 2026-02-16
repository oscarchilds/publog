using Microsoft.EntityFrameworkCore;
using PubLog.Models;

namespace PubLog.Data;

public class PubLogDbContext : DbContext
{
    public PubLogDbContext(DbContextOptions<PubLogDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Area> Areas => Set<Area>();
    public DbSet<Pub> Pubs => Set<Pub>();
    public DbSet<Visit> Visits => Set<Visit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(e =>
        {
            e.HasIndex(u => u.Username).IsUnique();
            e.Property(u => u.Username).HasMaxLength(50);
            e.Property(u => u.PasswordHash).HasMaxLength(200);
            e.Property(u => u.DisplayName).HasMaxLength(100);
            e.Property(u => u.Role).HasConversion<string>().HasMaxLength(20);
        });

        modelBuilder.Entity<Area>(e =>
        {
            e.HasIndex(a => a.Name).IsUnique();
            e.Property(a => a.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Pub>(e =>
        {
            e.Property(p => p.Name).HasMaxLength(200);
            e.Property(p => p.Description).HasMaxLength(2000);
            e.Property(p => p.Address).HasMaxLength(500);
            e.Property(p => p.ImageUrl).HasMaxLength(500);
            e.Property(p => p.GooglePlaceId).HasMaxLength(500);
            e.Property(p => p.TripAdvisorUrl).HasMaxLength(500);
            e.HasOne(p => p.Area).WithMany(a => a.Pubs).HasForeignKey(p => p.AreaId);
        });

        modelBuilder.Entity<Visit>(e =>
        {
            e.HasIndex(v => new { v.UserId, v.PubId }).IsUnique();
            e.Property(v => v.Notes).HasMaxLength(1000);
            e.HasOne(v => v.User).WithMany().HasForeignKey(v => v.UserId);
            e.HasOne(v => v.Pub).WithMany(p => p.Visits).HasForeignKey(v => v.PubId);
        });
    }
}
