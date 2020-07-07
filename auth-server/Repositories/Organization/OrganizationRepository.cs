using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using auth_server.Models.OrganizationModels;
using System;
using System.Linq;

namespace auth_server.Repositories.OrganizationContext
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly Context _dbContext;

        public OrganizationRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Organization>> GetAll()
        {
            return await _dbContext.Organizations.ToListAsync();
        }

        public async Task<Organization> GetById(Guid id)
        {
            return await _dbContext.Organizations
            .Where(org => org._oid == id)
            .SingleOrDefaultAsync();
        }

        public async Task<Organization> Create(Organization org)
        {
            _dbContext.Organizations.Add(org);
            await _dbContext.SaveChangesAsync();
            return await this.GetById(org._oid);
        }

        public async Task Delete(Organization org)
        {
            _dbContext.Organizations.Remove(org);
            await _dbContext.SaveChangesAsync();
        }

    }
}