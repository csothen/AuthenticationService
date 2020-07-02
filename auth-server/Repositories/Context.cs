using Microsoft.EntityFrameworkCore;

using auth_server.Models.OrganizationModels;

namespace auth_server.Repositories
{
    public class Context : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<UserTemplate> UserTemplates { get; set; }
    }
}