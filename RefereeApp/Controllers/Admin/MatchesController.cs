using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using RefereeApp.Models.ApiModels;
using WebAPI.Models;

namespace RefereeApp.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MatchesController : ControllerBase
    {
        private readonly AuthenticationContext _context;
        private UserManager<ApplicationUser> _userManager;

        public MatchesController(AuthenticationContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // PUT: api/Matches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatches(int id, Matches matches)
        {
            if (id != matches.Id)
            {
                return BadRequest();
            }

            _context.Entry(matches).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Zaktualizowano mecz poprawnie");
        }

        // POST: api/Matches
        [HttpPost]
        public async Task<ActionResult<Matches>> AddMatches(CreateMatchesRequest newEvent)
        {
            var referee = await _userManager.FindByIdAsync(newEvent.RefereeId);

            var match = new Matches
            {
                HomeTeamId = newEvent.HomeTeamId,
                AwayTeamId = newEvent.AwayTeamId,
                Description = newEvent.Description,
                StartDate = newEvent.StartDate
            };

            var userMatch = new UserMatches
            {
                Reffere = referee,
                Match = match
            };

            _context.Matches.Add(match);

            await _context.SaveChangesAsync();

            return Ok(match);
        }


        // DELETE: api/Matches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatches(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }

            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.Id == id);
        }
    }
}
