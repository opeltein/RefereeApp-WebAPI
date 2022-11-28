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
            var authUser = HttpContext.User;
            var userId = authUser.Claims.FirstOrDefault(claim => claim.Type == "UserID");

            
            if (userId == null)
                return NotFound("Nie znaleźiono tego użytkownika");

            result = await _context.Marks.Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(result);
        }

        // GET: api/Marks/userId
        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<IList<Marks>>> GetMarks(Guid userId, int page = 0, int pageSize = 10)
        {
            var userMarks = await _context.Marks.Where(mark => mark.User.Id == userId.ToString()).OrderBy(mark => mark.Id).Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(userMarks);
        }

        // PUT: api/Marks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarks(int id, Marks marks)
        {
            if (id != marks.Id)
            {
                return BadRequest();
            }

            _context.Entry(marks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarksExists(id))
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

        // POST: api/Marks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Finances>> PostMarks(CreateMarkRequest marks)
        {

            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Id == marks.UserId);

            if (user == null)
                return NotFound("Nie znaleźiono tego użytkownika");

            var markDb = new Marks
            {
                Mark = marks.Mark,
                User = user
            };
            _context.Marks.Add(markDb);
            await _context.SaveChangesAsync();

            return Ok(new CreateMarkResponse(markDb.Id));
        }

        // DELETE: api/Marks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarks(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }

            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarksExists(int id)
        {
            return _context.Marks.Any(e => e.Id == id);
        }
    }
}
