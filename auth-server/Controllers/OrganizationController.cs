using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace auth_server.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly ILogger<OrganizationController> _logger;

        public OrganizationController(ILogger<OrganizationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Está a dar alguma coisa");
        }
    }
}
