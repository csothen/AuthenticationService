using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

using auth_server.Services;
using auth_server.Models.OrganizationModels;
using System;

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
        public async Task<IActionResult> GetOrganizations()
        {
            try
            {
                ICollection<Organization> organizations = await this._service.GetOrganizations();
                if (organizations.Count == 0) return NotFound("There are currently no organizations registered");
                return Ok(organizations);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganizationById(string id)
        {
            try
            {
                Organization organization = await this._service.GetById(Guid.Parse(id));
                if (organization == null) return NotFound(String.Format("The organization with ID {0} does not exist", id));
                return Ok(organization);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrganization(Organization org)
        {
            try
            {
                Organization createdOrg = await this._service.Create(org);
                if (createdOrg == null) return BadRequest("The organization you tried to create already exists");
                return CreatedAtAction(nameof(GetOrganizationById), new { id = org._oid }, createdOrg);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(string id)
        {
            try
            {
                Organization org = await this._service.Delete(Guid.Parse(id));
                if (org == null) return NotFound(String.Format("The organization with ID {0} does not exist", id));
                return Ok(String.Format("The organization with ID {0} was successfully deleted", id));
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}
