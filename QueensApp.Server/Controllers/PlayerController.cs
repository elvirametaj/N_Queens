using Microsoft.AspNetCore.Mvc;
using QueensApp.Server.Repositories;

namespace QueensApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(ILogger<PlayerController> logger, IPlayerRepository playerRepository)
        {
            _logger = logger;
            _playerRepository = playerRepository;
        }

        [HttpPost("Register")]
        public string Register(string username)
        {
            //save to database player
            //_playerRepository.Create()
            return username;
        }
    }
}
