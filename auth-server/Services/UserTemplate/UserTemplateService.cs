using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using auth_server.Models.UserTemplateModels;
using auth_server.Repositories.UserTemplateContext;

namespace auth_server.Services
{
    public class UserTemplateService : IUserTemplateService
    {

        private readonly IUserTemplateRepository _repo;

        public UserTemplateService(IUserTemplateRepository repo)
        {
            this._repo = repo;
        }

        public async Task<ICollection<UserTemplateDTO>> GetAll()
        {
            try
            {
                ICollection<UserTemplateDTO> dtos = new List<UserTemplateDTO>();
                ICollection<UserTemplate> templates = await this._repo.GetAll();
                foreach (UserTemplate t in templates)
                {
                    dtos.Add(new UserTemplateDTO(t._tid, t.attributes));
                }
                return dtos;
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching User Templates");
            }
        }

        public async Task<UserTemplateDTO> GetById(Guid id)
        {
            try
            {
                UserTemplate template = await this._repo.GetById(id);
                if (template != null)
                {
                    UserTemplateDTO dto = new UserTemplateDTO(template._tid, template.attributes);
                    return dto;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching a User Template");
            }
        }

        public async Task<UserTemplateDTO> Create(UserTemplate template)
        {
            try
            {
                UserTemplateDTO existingTemplate = await this.GetById(template._tid);
                if (existingTemplate != null) return null;
                UserTemplate createdTemplate = await this._repo.Create(template);
                UserTemplateDTO dto = new UserTemplateDTO(createdTemplate._tid, createdTemplate.attributes);
                return dto;
            }
            catch (Exception)
            {
                throw new Exception("Internal error creating a User Template");
            }
        }

        public async Task<UserTemplateDTO> Delete(Guid id)
        {
            try
            {
                UserTemplate template = await this._repo.GetById(id);
                if (template == null) return null;
                await this._repo.Delete(template);
                UserTemplateDTO dto = new UserTemplateDTO(template._tid, template.attributes);
                return dto;
            }
            catch (System.Exception)
            {
                throw new Exception("Internal error deleting an existing User Template");
            }
        }
    }
}