using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.UserTemplateModels;

namespace auth_server.Repositories.UserTemplateContext
{
    public interface IUserTemplateRepository
    {
        Task<ICollection<UserTemplate>> GetAll();
        Task<UserTemplate> GetById(Guid id);
        Task<UserTemplate> Create(UserTemplate template);
        Task Destroy(UserTemplate template);
    }

}