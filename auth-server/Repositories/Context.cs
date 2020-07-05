using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using auth_server.Models.OrganizationModels;
using auth_server.Models.CountryModels;

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
            modelBuilder.Entity<Organization>().HasKey(o => o._oid);
            modelBuilder.Entity<Organization>().HasOne<UserTemplate>().WithMany().HasForeignKey(o => o._templateId);
            modelBuilder.Entity<Country>().HasKey(c => c._cid);
            modelBuilder.Entity<UserTemplate>().HasKey(u => u._tid);
        }
    }
}