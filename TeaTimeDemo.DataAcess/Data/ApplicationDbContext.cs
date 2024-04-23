using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Store> Stores { get; set; }

        public DbSet<ApplicationUsers> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "茶", DisplayOrder = 1 },
                new Category { Id = 2, Name = "水果茶", DisplayOrder = 2 },
                new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "台灣水果茶", Size = "大", Price = 60, Description = "天然,好喝", CategoryId = 1, ImageUrl = "" },
                new Product { Id = 2, Name = "鐵觀音", Size = "中", Price = 35, Description = "讚", CategoryId = 1, ImageUrl = "" },
                new Product { Id = 3, Name = "美式咖啡", Size = "中", Price = 50, Description = "棒透了", CategoryId = 3, ImageUrl = "" }
                );
        }
    }
}
