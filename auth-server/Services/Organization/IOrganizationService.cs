using System.Threading.Tasks;
using System.Collections.Generic;

using auth_server.Models.OrganizationModels;
using System;

namespace auth_server.Services
{
    public interface IOrganizationService
    {
        Task<ICollection<Organization>> GetOrganizations();
        Task<Organization> GetById(Guid id);
        Task<Organization> Create(Organization org);
        Task<Organization> Delete(Guid id);
    }
}