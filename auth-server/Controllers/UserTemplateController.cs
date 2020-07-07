using Microsoft.AspNetCore.Mvc;

using auth_server.Models.UserTemplateModels;
using auth_server.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace auth_server.Controllers
{
    [Route("/template")]
    public class UserTemplateController : Controller
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
                ICollection<UserTemplate> templates = await this._service.GetAll();
                if (templates.Count == 0) return NotFound("There are currently no templates registered");
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
                UserTemplate template = await this._service.GetById(Guid.Parse(id));
                if (template == null) return NotFound(String.Format("The template with ID {0} does not exist", id));
                return Ok(template);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(UserTemplate template)
        {
            try
            {
                UserTemplate createdTemplate = await this._service.Create(template);
                if (createdTemplate == null) return BadRequest("The template you tried to create already exists");
                return CreatedAtAction(nameof(GetTemplateById), new { id = template._tid }, createdTemplate);
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
                UserTemplate template = await this._service.Delete(Guid.Parse(id));
                if (template == null) return NotFound(String.Format("The template with ID {0} does not exist", id));
                return Ok(String.Format("The template with ID {0} was successfully deleted", id));
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }
    }
}