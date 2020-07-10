using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using auth_server.Services;
using auth_server.Controllers.Commands;
using System.Threading.Tasks;
using auth_server.Models.Authentication;
using System;

namespace auth_server.Controllers
{

    [ApiController]
    [Route("/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _service;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService service)
        {
            this._logger = logger;
            this._service = service;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            try
            {
                AuthenticationResponse response = await this._service.login(command);
                if (response == null) return Unauthorized();
                return Ok(response);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            try
            {
                AuthenticationResponse response = await this._service.register(command);
                if (response == null) return Unauthorized();
                return Ok(response);
            }
            catch (Exception e)
            {
                this._logger.LogError(e, e.Message);
                return StatusCode(500);
            }
        }

    }
}