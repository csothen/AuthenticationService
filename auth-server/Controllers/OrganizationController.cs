using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Services;
using auth_server.Models.OrganizationModels;
using System;
using Microsoft.AspNetCore.Authorization;
using auth_server.Models.Responses;

namespace auth_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/organization")]
    public class OrganizationController : ControllerBase
    {
        private readonly ILogger<OrganizationController> _logger;
        private readonly IOrganizationService _service;

        public OrganizationController(ILogger<OrganizationController> logger, IOrganizationService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            try
            {
                ICollection<Organization> organizations = await this._service.GetOrganizations();
                if (organizations.Count == 0) return NotFound(new Error("There are currently no organizations registered"));
                return Ok(organizations);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetOrganizationByEmail(string email)
        {
            try
            {
                Organization organization = await this._service.GetByEmail(email);
                if (organization == null) return NotFound(new Error(String.Format("The organization with email {0} does not exist", email)));
                return Ok(organization);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteOrganization(string email)
        {
            try
            {
                Organization org = await this._service.Delete(email);
                if (org == null) return NotFound(new Error(String.Format("The organization with email {0} does not exist", email)));
                return Ok(new Success(String.Format("The organization with email {0} was successfully deleted", email)));
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}
