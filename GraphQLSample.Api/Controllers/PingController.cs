using Microsoft.AspNetCore.Mvc;

namespace GraphQLSample.Api.Controllers
{
    [ApiController]
    [Route("ping")]
    public class PingController : ControllerBase
    {
        public PingController() { }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}
