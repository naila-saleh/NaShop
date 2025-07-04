using Microsoft.EntityFrameworkCore;
using NaShop.Models;

namespace NaShop.Data;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=.;Database=NaShop;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category {Id=1,Name = "Mobiles"},
            new Category {Id=2,Name = "Cameras"},
            new Category {Id=3,Name = "Tablets"},
            new Category {Id=4,Name = "Laptops"},
            new Category {Id=5,Name = "Accessories"}
            );
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }
}