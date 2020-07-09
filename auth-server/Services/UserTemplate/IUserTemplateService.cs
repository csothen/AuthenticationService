using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using auth_server.Models.UserTemplateModels;

namespace auth_server.Services
{
    public interface IUserTemplateService
    {
        Task<ICollection<UserTemplateDTO>> GetAll();
        Task<UserTemplateDTO> GetById(Guid id);
        Task<UserTemplateDTO> Create(UserTemplate templateDTO);
        Task<UserTemplateDTO> Delete(Guid id);
    }
}