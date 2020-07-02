using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.OrganizationModels;

namespace auth_server.Repositories.OrganizationContext
{
    public interface IOrganizationRepository
    {
        Task<List<Organization>> GetAll();
    }
}