using Microsoft.AspNetCore.Authorization;
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
    public class StadiumsController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public StadiumsController(AuthenticationContext context)
        {
            _context = context;
        }

        // PUT: api/Stadiums/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStadiums(int id, Stadiums stadiums)
        {
            if (id != stadiums.Id)
            {
                return BadRequest();
            }

            _context.Entry(stadiums).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StadiumsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Stadiums
        [HttpPost]
        public async Task<ActionResult<List<Stadiums>>> AddStadium(CreateStadiumsRequest newEvent)
        {
            _context.Stadiums.Add(new Stadiums
            {
                Name = newEvent.Name,
                City = newEvent.City,
                Street = newEvent.Street,
                PostalCode = newEvent.PostalCode

            });

            await _context.SaveChangesAsync();

            return Ok(await _context.Stadiums.ToListAsync());
        }

        // DELETE: api/Stadiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStadiums(int id)
        {
            var stadiums = await _context.Stadiums.FindAsync(id);
            if (stadiums == null)
            {
                return NotFound();
            }

            _context.Stadiums.Remove(stadiums);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StadiumsExists(int id)
        {
            return _context.Stadiums.Any(e => e.Id == id);
        }
    }
}
