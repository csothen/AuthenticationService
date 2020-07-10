using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using auth_server.Controllers.Commands;
using auth_server.Models.UserTemplateModels;

namespace auth_server.Services
{
    public interface IUserTemplateService
    {
        Task<ICollection<UserTemplateDTO>> GetAll();
        Task<UserTemplateDTO> GetById(Guid id);
        Task<UserTemplateDTO> Create(Guid orgID, CreateTemplateCommand command);
        Task<UserTemplateDTO> Delete(Guid id);
    }
}