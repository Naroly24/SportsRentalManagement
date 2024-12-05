using Microsoft.AspNetCore.Mvc;
using SportsRentalManagement.Models;
using System.Diagnostics;

namespace SportsRentalManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: api/Home
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "Welcome to the Sports Rental Management API!" });
            // Retorna un mensaje de bienvenida en formato JSON
        }

        // GET: api/Home/Privacy
        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return Ok(new { message = "Privacy Policy" });
            // Retorna un mensaje sobre la privacidad en formato JSON
        }

        // GET: api/Home/Error
        [HttpGet("error")]
        public IActionResult Error()
        {
            var errorModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return Ok(errorModel);
            // Retorna un modelo de error en formato JSON
        }
    }
}
