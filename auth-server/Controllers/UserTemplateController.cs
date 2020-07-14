using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

using auth_server.Models.UserTemplateModels;
using auth_server.Services;
using auth_server.Controllers.Commands;
using auth_server.Models.Responses;
using auth_server.Utils;

namespace auth_server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/template")]
    public class UserTemplateController : ControllerBase
    {
        private readonly ILogger<UserTemplateController> _logger;
        private readonly IUserTemplateService _service;

        public UserTemplateController(ILogger<UserTemplateController> logger, IUserTemplateService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplates()
        {
            try
            {
                ICollection<UserTemplateDTO> templates = await this._service.GetAll();
                if (templates.Count == 0) return NotFound(new Error("There are currently no templates registered"));
                return Ok(templates);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateById(string id)
        {
            try
            {
                UserTemplateDTO template = await this._service.GetById(Guid.Parse(id));
                if (template == null) return NotFound(new Error(String.Format("The template with ID {0} does not exist", id)));
                return Ok(template);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpGet("org/{email}")]
        public async Task<IActionResult> GetTemplatesByOrg(string email)
        {
            try
            {
                ICollection<UserTemplateDTO> templates = await this._service.GetByOrg(email);
                return Ok(templates);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate([FromBody] CreateTemplateCommand command)
        {
            try
            {
                string orgEmail = JwtClaim.GetEmail(User);
                UserTemplateDTO createdTemplate = await this._service.Create(orgEmail, command);
                return Created("template/", createdTemplate._tid);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(string id)
        {
            try
            {
                UserTemplateDTO template = await this._service.Delete(Guid.Parse(id));
                if (template == null) return NotFound(new Error(String.Format("The template with ID {0} does not exist", id)));
                return Ok(new Success(String.Format("The template with ID {0} was successfully deleted", id)));
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}