using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using RefereeApp.Models.ApiModels;
using WebAPI.Models;

namespace RefereeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Referee")]
    public class PlayersController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public PlayersController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IList<Players>>> GetPlayers(int page = 0, int pageSize = 10)
        {
            IList<Players> result = new List<Players>();
            if (_context.Roles.Any(role => role.Name == "Referee"))
            {
                result = await _context.Players.Skip(page * pageSize).Take(pageSize).ToListAsync();
            }
            else if (_context.Roles.Any(role => role.Name == "Admin"))
            {
                result = await _context.Players.AsNoTracking().Skip(page * pageSize).Take(pageSize).ToListAsync();
            }
            return Ok(result);
        }


        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> GetPlayers(int id)
        {
            var players = await _context.Players.FindAsync(id);

            if (players == null)
            {
                return NotFound();
            }

            return players;
        }

        // POST: api/Players
        [HttpPost]
        public async Task<ActionResult<Players>> PostPlayers(CreatePlayerRequest player)
        {
            var playerDb = new Players
            {
                Name = player.Name,
                Surname = player.Surname,
                Nationality = player.Nationality,
                JerseyNumber = player.JerseyNumber,
                TeamsId = player.TeamsId
            };
            _context.Players.Add(playerDb);
            await _context.SaveChangesAsync();

            return Ok(new CreatePlayerResponse(playerDb.Id));
        }

        private bool PlayersExists(int id)
        {
            return _context.Players.Any(e => e.Id == id);
        }
    }
}
