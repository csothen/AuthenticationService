using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Services;
using auth_server.Models.OrganizationModels;

namespace auth_server.Controllers
{
    [Route("/organization")]
    public class OrganizationController : Controller
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationService _service;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganization()
        {
            List<Organization> organizations = await this._service.GetOrganizations();
            return Ok(organizations);
        }
    }
}
