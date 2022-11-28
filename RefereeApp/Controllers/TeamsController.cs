using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using WebAPI.Models;

namespace RefereeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Referee")]
    public class TeamsController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public TeamsController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Teams
        [HttpGet]
        public async Task<ActionResult<IList<Teams>>> GetTeams(int page = 0, int pageSize = 10)
        {
            IList<Teams> result = new List<Teams>();
            result = await _context.Teams.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }


        // GET: api/Teams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teams>> GetTeams(int id)
        {
            var teams = await _context.Teams.FindAsync(id);

            if (teams == null)
            {
                return NotFound();
            }

            return teams;
        }

        private bool TeamsExists(int id)
        {
            return _context.Teams.Any(e => e.Id == id);
        }
    }
}
