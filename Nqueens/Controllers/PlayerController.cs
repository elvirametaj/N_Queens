using Microsoft.AspNetCore.Mvc;
using Nqueens.Models.Entities;
using Nqueens.Data;
namespace Nqueens.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostUsername([FromBody] UsernameModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username))
            {
                return BadRequest("Invalid username.");
            }

            // Save the username to the database
            var player = new Player { Username = model.Username };
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return Ok("Username successfully stored in the database.");
        }
    }

    public class UsernameModel
    {
        public string Username { get; set; }
    }
}
