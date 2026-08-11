using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace proj1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelathCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("Api is running");
        }
        [HttpGet("/")]
        public IActionResult HealthCheckHome()
        {
            return Ok("Api is running");
        }
        [HttpGet("apitest")]
        public IActionResult HealthCheckHome2()
        {
            return Ok("Api is running");
        }
        [HttpGet("/apitest")]
        public IActionResult HealthCheckHome3()
        {
            return Ok("Api is running");
        }
    }
}
