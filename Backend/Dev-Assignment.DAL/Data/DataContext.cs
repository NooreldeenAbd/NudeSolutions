using Dev_Assignment.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace Dev_Assignment.DAL.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<InsuredItem> InsuredItems { get; set; }
        public string DbPath { get; }

        public DataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "InsuredItems.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InsuredItem>().HasData(
                new InsuredItem { Id = 1, catagoryId = 1, value = 2500, Name = "TV" },
                new InsuredItem { Id = 2, catagoryId = 1, value = 500, Name = "Playstation 5" },
                new InsuredItem { Id = 3, catagoryId = 1, value = 1500, Name = "Laptop" },
                new InsuredItem { Id = 4, catagoryId = 1, value = 4000, Name = "Electric guitar" },

                new InsuredItem { Id = 5, catagoryId = 2, value = 100, Name = "Shoes" },
                new InsuredItem { Id = 6, catagoryId = 2, value = 2000, Name = "Suit" },
                new InsuredItem { Id = 7, catagoryId = 2, value = 400, Name = "Jacket" },

                new InsuredItem { Id = 8, catagoryId = 3, value = 2200, Name = "Oven" },
                new InsuredItem { Id = 9, catagoryId = 3, value = 1500, Name = "Dishwasher" },
                new InsuredItem { Id = 10, catagoryId = 3, value = 790, Name = "Microwave" }
                );
        }
    }
}
