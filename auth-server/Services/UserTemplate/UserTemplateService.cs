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

        public async Task<ICollection<UserTemplate>> GetAll()
        {
            try
            {
                ICollection<UserTemplate> templates = await this._repo.GetAll();
                return templates;
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching User Templates");
            }
        }

        public async Task<UserTemplate> GetById(Guid id)
        {
            try
            {
                UserTemplate template = await this._repo.GetById(id);
                return template;
            }
            catch (Exception)
            {
                throw new Exception("Internal error fetching a User Template");
            }
        }

        public async Task<UserTemplate> Create(UserTemplate template)
        {
            try
            {
                UserTemplate existingTemplate = await this.GetById(template._tid);
                if (existingTemplate != null) return null;
                UserTemplate createdTemplate = await this._repo.Create(template);
                return createdTemplate;
            }
            catch (Exception)
            {
                throw new Exception("Internal error creating a User Template");
            }
        }

        public async Task<UserTemplate> Delete(Guid id)
        {
            try
            {
                UserTemplate template = await this.GetById(id);
                if (template == null) return null;
                await this._repo.Delete(template);
                return template;
            }
            catch (System.Exception)
            {
                throw new Exception("Internal error deleting an existing User Template");
            }
        }
    }
}