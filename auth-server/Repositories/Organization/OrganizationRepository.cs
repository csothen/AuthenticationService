using Microsoft.EntityFrameworkCore.SqlServer;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using auth_server.Models.OrganizationModels;

namespace auth_server.Repositories.OrganizationContext
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly Context _dbContext;

        public OrganizationRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Organization>> GetAll()
        {
            return await _dbContext.Organizations.ToListAsync();
        }
    }
}