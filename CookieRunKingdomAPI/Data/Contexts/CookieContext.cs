using Microsoft.EntityFrameworkCore;
using CookieRunKingdomAPI.Models;

namespace CookieRunKingdomAPI.Data.Contexts;

public class CookieContext : DbContext
{
    public CookieContext(DbContextOptions<CookieContext> options) : base(options) { }

    public DbSet<Cookie> Cookies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cookie>(entity =>
        {
            entity.ToTable("cookie");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Rarity).HasColumnName("rarity");
            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Position).HasColumnName("position");
        });
    }
}
