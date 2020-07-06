using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Services;
using auth_server.Models.CountryModels;

namespace auth_server.Controllers
{
    [Route("/countries")]
    public class CountryController : Controller
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryService _service;

        public CountryController(ILogger<CountryController> logger, ICountryService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Setup()
        {
            bool success = await this._service.SetupCountries();
            if (success)
            {
                ICollection<Country> countries = await this._service.GetCountries();
                return Ok(countries);
            }
            else
            {
                return BadRequest("Failed to setup");
            }
        }
    }
}