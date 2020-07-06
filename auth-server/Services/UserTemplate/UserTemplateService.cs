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
                UserTemplate createdTemplate = await this._repo.Create(template);
                return template;
            }
            catch (Exception)
            {
                throw new Exception("Internal error creating a User Template");
            }
        }

        public async Task Destroy(UserTemplate template)
        {
            try
            {
                await this._repo.Destroy(template);
            }
            catch (System.Exception)
            {
                throw new Exception("Internal error destroying an existing User Template");
            }
        }
    }
}