using System;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Country>> GetAll()
        {
            return await _dbContext.Countries.ToListAsync();
        }

        public async Task<bool> Create(Country c)
        {
            try
            {
                _dbContext.Countries.Add(c);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}