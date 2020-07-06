using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using auth_server.Models.CountryModels;

namespace auth_server.Repositories.CountryContext
{
    public class CountryRepository : ICountryRepository
    {
        private readonly Context _dbContext;

        public CountryRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<Country>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task Create(Country c)
        {

            _dbContext.Countries.Add(c);
            await _dbContext.SaveChangesAsync();

        }
    }
}