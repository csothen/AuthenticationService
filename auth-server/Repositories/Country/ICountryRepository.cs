using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.CountryModels;

namespace auth_server.Repositories.CountryContext
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<bool> Create(Country c);
    }
}