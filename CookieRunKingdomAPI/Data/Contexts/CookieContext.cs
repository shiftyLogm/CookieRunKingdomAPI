using Microsoft.EntityFrameworkCore;
using CookieRunKingdomAPI.Models;
using CookieRunKingdomAPI.Enums;

namespace CookieRunKingdomAPI.Data.Contexts;

public class CookieContext : DbContext
{
    public CookieContext(DbContextOptions<CookieContext> options) : base(options) { }

    public DbSet<Cookie> Cookies { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cookie>(entity => entity.ToTable("cookie"));
    }
}
