﻿using Microsoft.EntityFrameworkCore;
using TeaTimeDemo.Models;

namespace TeaTimeDemo.DataAcess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1,Name="茶",DisplayOrder=1},
                new Category { Id = 2, Name = "水果茶", DisplayOrder = 2 },
                new Category { Id = 3, Name = "咖啡", DisplayOrder = 3 }
                );
        }
    }
}