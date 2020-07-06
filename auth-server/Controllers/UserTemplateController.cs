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
                if (templates.Count == 0)
                {
                    return NotFound("There are currently no templates registered");
                }
                return Ok(templates);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateById(string id)
        {
            try
            {
                UserTemplate template = await this._service.GetById(Guid.Parse(id));
                if (template == null)
                {
                    return NotFound(String.Format("The template with ID {0} does not exist", id));
                }
                return Ok(template);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate(UserTemplate template)
        {
            try
            {
                UserTemplate createdTemplate = await this._service.Create(template);
                return CreatedAtAction(nameof(GetTemplateById), new { id = template._tid }, createdTemplate);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DestroyTemplate(string id)
        {
            try
            {
                UserTemplate template = await this._service.GetById(Guid.Parse(id));
                if (template == null)
                {
                    return NotFound(String.Format("The template with ID {0} does not exist", id));
                }
                await this._service.Destroy(template);
                return Ok(String.Format("The template with ID {0} was successfully deleted", id));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}