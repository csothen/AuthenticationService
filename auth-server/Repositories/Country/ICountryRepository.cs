using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Models.CountryModels;

namespace auth_server.Repositories.CountryContext
{
    public interface ICountryRepository
    {
        Task<ICollection<Country>> GetAll();
        Task Create(Country c);
    }
}