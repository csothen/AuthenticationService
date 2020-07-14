using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.OrganizationModels;
using auth_server.Repositories.OrganizationContext;

namespace auth_server.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _repo;

        public OrganizationService(IOrganizationRepository repo)
        {
            this._repo = repo;
        }


        public async Task<ICollection<Organization>> GetOrganizations()
        {
            try
            {
                ICollection<Organization> orgs = await _repo.GetAll();
                return orgs;
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching Organizations");
            }
        }

        public async Task<Organization> GetByEmail(string email)
        {
            try
            {
                Organization org = await _repo.GetByEmail(email);
                return org;
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching an Organization");
            }
        }

        public async Task<Organization> Create(Organization org)
        {
            try
            {
                Organization existingOrg = await this.GetByEmail(org.email);
                if (existingOrg != null) return null;
                Organization createdOrg = await this._repo.Create(org);
                return createdOrg;
            }
            catch (Exception)
            {
                throw new Exception("Internal error creating an Organization");
            }
        }

        public async Task<Organization> Delete(string email)
        {
            try
            {
                Organization org = await this.GetByEmail(email);
                if (org == null) return null;
                await this._repo.Delete(org);
                return org;
            }
            catch (Exception)
            {
                throw new Exception("Internal error deleting an existing Organization");
            }
        }

        public async Task<Organization> Update(Organization updatedOrg)
        {
            try
            {
                Organization org = await this.GetByEmail(updatedOrg.email);
                if (org == null) return null;
                await this._repo.Update(updatedOrg);
                return updatedOrg;
            }
            catch (Exception)
            {
                throw new Exception("Internal error updating an existing Organization");
            }
        }

    }
}