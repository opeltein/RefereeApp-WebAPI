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
    public class StadiumsController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public StadiumsController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Stadiums
        [HttpGet]
        public async Task<ActionResult<IList<Stadiums>>> Get(int page = 0, int pageSize = 10)
        {
            IList<Stadiums> result = new List<Stadiums>();
            result = await _context.Stadiums.Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }


        // GET: api/Stadiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stadiums>> GetStadiums(int id)
        {
            var stadiums = await _context.Stadiums.FindAsync(id);

            if (stadiums == null)
            {
                return NotFound();
            }

            return stadiums;
        }

      
    }
}
       
       