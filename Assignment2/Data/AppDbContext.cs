using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Assignment2.Data
{
    
    public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)

        {
            var userCredentials = new UserCredentials
            {
                Id = -1,
                Email = "user@example.com",
                Password = "password123"
            };

            builder.Entity<UserCredentials>().HasData(userCredentials);
            base.OnModelCreating(builder);

            // Configure table names
            builder.Entity<IdentityRole>().ToTable("AspNetRoles");
            builder.Entity<IdentityUser>().ToTable("AspNetUsers");
        }
        public DbSet<Employee> Employeed { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }

        // Other DbSet properties and additional configurations
    }

}