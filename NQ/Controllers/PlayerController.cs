using Microsoft.AspNetCore.Mvc;
using NQ.Models.Entities;
using NQ.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NQ.Models.Entities;

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
    public async Task<IActionResult> PostUsername([FromForm] UsernameModel model)
    {
        if (model == null || string.IsNullOrEmpty(model.Username))
        {
            return BadRequest("Invalid username.");
        }
        HttpContext.Session.SetString("LoggedInUsername", model.Username);

        // Save the username to the database
        var player = new Player { Username = model.Username };
        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return Redirect("/pages/chooselevel.html");
    }

    [HttpGet("get-username")]
    public IActionResult GetLoggedInUsername()
    {
        // Retrieve the username from the session
        var loggedInUsername = HttpContext.Session.GetString("LoggedInUsername");

        if (string.IsNullOrEmpty(loggedInUsername))
        {
            return BadRequest("User not authenticated.");
        }

        return Ok(loggedInUsername);
    }
}

public class UsernameModel
{
    public string Username { get; set; }
}