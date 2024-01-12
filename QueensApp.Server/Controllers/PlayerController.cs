using Microsoft.AspNetCore.Mvc;

namespace QueensApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;

        public PlayerController(ILogger<PlayerController> logger)
        {
            _logger = logger;
        }

        [HttpPost("Register")]
        public string Register(string username)
        {
            //save to database player
            return username;
        }
    }
}
