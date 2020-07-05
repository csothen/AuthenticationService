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

        public async Task<List<Organization>> GetOrganizations()
        {
            List<Organization> orgs = await _repo.GetAll();
            return orgs;
        }

    }
}