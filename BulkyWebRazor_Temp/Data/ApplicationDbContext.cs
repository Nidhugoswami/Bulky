using BulkyWebRazor_Temp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BulkyWebRazor_Temp.Data
{
    public class ApplicatiobDbContext : DbContext
    {
        public ApplicatiobDbContext(DbContextOptions<ApplicatiobDbContext> options) : base(options)  // initialse krdiya
        {
            
        }

        public DbSet<Category> Categories { get; set; } // table bana di

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "History", DisplayOrder = 3 }
                );
        }
    }
}
