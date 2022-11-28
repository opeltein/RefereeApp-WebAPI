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

    public class SingleTeamController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public SingleTeamController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/SingleTeams/TeamId
        [HttpGet("{TeamId}")]

        public async Task<ActionResult<IList<Players>>> GetTeams(int TeamId, int page = 0, int pageSize = 10)
        {
            var teamPlayers = await _context.Players.Where(team => team.TeamsId.ToString() == TeamId.ToString()).OrderBy(team => team.Id).Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(teamPlayers);
        }
    }
}
