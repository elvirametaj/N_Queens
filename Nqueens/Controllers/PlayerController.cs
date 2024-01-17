using Microsoft.AspNetCore.Mvc;
using Nqueens.Models.Entities;
using Nqueens.Data;
namespace Nqueens.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        // first part added here

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
    // second part added here

}
