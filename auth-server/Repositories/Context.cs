using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using auth_server.Models.OrganizationModels;
using auth_server.Models.CountryModels;
using auth_server.Models.UserTemplateModels;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace auth_server.Repositories
{
    public class Context : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<UserTemplate> UserTemplates { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Organization
            modelBuilder.Entity<Organization>().HasKey(o => o.email);
            modelBuilder.Entity<Organization>().HasMany(o => o._templates).WithOne(t => t.organization);

            // Countries
            modelBuilder.Entity<Country>().HasKey(c => c._name);

            // User Templates
            modelBuilder.Entity<UserTemplate>().HasKey(u => u._tid);
            modelBuilder.Entity<UserTemplate>().HasOne(t => t.organization);
        }
    }
}