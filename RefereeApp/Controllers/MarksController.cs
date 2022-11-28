using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using RefereeApp.Utils;
using WebAPI.Models;

namespace RefereeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Referee")]
    public class MarksController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public MarksController(AuthenticationContext context)
        {
            _context = context;
        }

        // GET: api/Marks
        [HttpGet]
        public async Task<ActionResult<IList<Marks>>> GetMarks(int page = 0, int pageSize = 10)
        {
            IList<Marks> result = new List<Marks>();
            result = await _context.Marks.Where(calendarEvent => calendarEvent.User != null && calendarEvent.User.Id == HttpContext.GetUserId()).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }

        // GET: api/Marks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Marks>> GetMarks(int id)
        {
            var marks = await _context.Marks.FindAsync(id);

            if (marks == null)
            {
                return NotFound();
            }

            return marks;
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.Id == id);
        }
    }
}
