using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteLibrary.Models.Configuration;

namespace WebsiteLibrary.Models
{
    public class WebsiteLibraryContext : IdentityDbContext<User>
    {
        public WebsiteLibraryContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Book> BooksList { get; set; }

        public DbSet<Category> CategoriesList { get; set; }

        public DbSet<Province> Provinces { get; set; }

        public DbSet<District> Districts { get; set; }
    }
}
