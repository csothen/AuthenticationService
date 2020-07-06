using System.Threading.Tasks;
using System.Collections.Generic;

using auth_server.Models.CountryModels;

namespace auth_server.Services
{
    public interface ICountryService
    {
        Task<bool> SetupCountries();
        Task<ICollection<Country>> GetCountries();
    }
}