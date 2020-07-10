using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.OrganizationModels;

namespace auth_server.Repositories.OrganizationContext
{
    public interface IOrganizationRepository
    {
        Task<ICollection<Organization>> GetAll();
        Task<Organization> GetById(Guid id);
        Task<Organization> GetByEmail(string email);
        Task<Organization> Create(Organization org);
        Task Delete(Organization org);
        Task Update(Organization org);
    }
}