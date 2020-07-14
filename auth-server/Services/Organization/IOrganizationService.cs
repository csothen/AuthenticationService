using System.Threading.Tasks;
using System.Collections.Generic;

using auth_server.Models.OrganizationModels;
using System;

namespace auth_server.Services
{
    public interface IOrganizationService
    {
        Task<ICollection<Organization>> GetOrganizations();
        Task<Organization> GetByEmail(string email);
        Task<Organization> Create(Organization org);
        Task<Organization> Update(Organization org);
        Task<Organization> Delete(string email);
    }
}