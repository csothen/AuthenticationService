using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using auth_server.Models.UserTemplateModels;
using System.Linq;

namespace auth_server.Repositories.UserTemplateContext
{
    public class UserTemplateRepository : IUserTemplateRepository
    {
        private readonly Context _dbContext;

        public UserTemplateRepository(Context dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ICollection<UserTemplate>> GetAll()
        {
            return await _dbContext.UserTemplates.ToListAsync();
        }

        public async Task<UserTemplate> GetById(Guid id)
        {
            return await _dbContext.UserTemplates
            .Where(template => template._tid == id)
            .SingleOrDefaultAsync();
        }

        public async Task<ICollection<UserTemplate>> GetByOrg(string email)
        {
            return await _dbContext.UserTemplates
            .Where(template => template.organization.email == email)
            .ToListAsync();
        }

        public async Task<UserTemplate> Create(UserTemplate template)
        {
            _dbContext.UserTemplates.Add(template);
            await _dbContext.SaveChangesAsync();
            return await this.GetById(template._tid);
        }

        public async Task Delete(UserTemplate template)
        {
            _dbContext.UserTemplates.Remove(template);
            await _dbContext.SaveChangesAsync();
        }

    }

}