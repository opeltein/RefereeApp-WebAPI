using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
    public class MatchesController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private UserManager<ApplicationUser> _userManager;

        public MatchesController(AuthenticationContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        

      

        [HttpGet("{id}")]
        public async Task<ActionResult<Matches>> GetMatches(int id)
        {
            var matches = await _context.Matches.FindAsync(id);

            if (matches == null)
            {
                return NotFound();
            }

            return matches;
        }

        // GET ALL: api/Matches
        [HttpGet]
        public async Task<ActionResult<IList<Matches>>> GetAllMatches(int page = 0, int pageSize = 10)
        {
            IList<Matches> result = new List<Matches>();
            result = await _context.Matches.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }

        //GET MY MATCHES: api/Matches
        [HttpGet("GetMyMatches")]
        public async Task<ActionResult<IList<Matches>>> GetMyMatches(int page = 0, int pageSize = 10)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            IList <Matches> result = new List<Matches>();
            result = await _context.Matches.ToListAsync();
            result = result.Where(x => x.UserMatches.Any(y => y.Reffere.Id == currentUser.Id)).Skip(page * pageSize).Take(pageSize).ToList();
            
            return Ok(result);
        }

        
        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
