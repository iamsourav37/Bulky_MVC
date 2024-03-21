﻿using BulkyWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Category> categories = new List<Category>();

            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category() { Id = i + 1, DisplayOrder = i + 1, Name = $"Category {i + 1}" });
            }

            modelBuilder.Entity<Category>().HasData(categories);
        }
    }
}
