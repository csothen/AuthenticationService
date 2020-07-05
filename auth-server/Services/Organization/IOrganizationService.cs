using System.Threading.Tasks;
using System.Collections.Generic;

using auth_server.Models.OrganizationModels;

namespace auth_server.Services
{
    public interface IOrganizationService
    {
        Task<List<Organization>> GetOrganizations();
    }
}