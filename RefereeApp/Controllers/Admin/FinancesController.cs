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
    public class FinancesController : ControllerBase
    {
        private readonly AuthenticationContext _context;

        public FinancesController(AuthenticationContext context)
        {
            this._context = context;
        }

        // GET: api/Finances
        [HttpGet]
        public async Task<ActionResult<IList<Finances>>> GetFinances(int page = 0, int pageSize = 10)
        {
            IList<Finances> result = new List<Finances>();
            var authUser = HttpContext.User;
            var userId = authUser.Claims.FirstOrDefault(claim => claim.Type == "UserID");

            if (userId == null) 
                return NotFound("Nie znaleźiono tego użytkownika");
           

            result = await _context.Finances.Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(result);
        }

        // GET: api/Finances/userId
        [HttpGet("{userId:guid}")]

        public async Task<ActionResult<IList<Finances>>> GetFinances(Guid userId, int page = 0, int pageSize = 10)
        {
            var userFinances = await _context.Finances.Where(finance => finance.User.Id == userId.ToString()).OrderBy(finance => finance.Id).Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(userFinances);
        }

        // PUT: api/Finances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinances(int id, Finances finances)
        {
            if (id != finances.Id)
            {
                return BadRequest();
            }

            _context.Entry(finances).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinancesExists(id))
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

        // POST: api/Finances
        [HttpPost]
        public async Task<ActionResult<Finances>> PostFinances(CreateFinanceRequest finances)
        {

            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Id == finances.UserId);

           

            if (user == null) 
                return NotFound("Nie znaleziono danych finansowych tego użytkownika");

            var financeDb = new Finances
            {
                Amount = finances.Amount,
                User = user
            };
            _context.Finances.Add(financeDb);
            await _context.SaveChangesAsync();

            return Ok(new CreateFinanceResponse(financeDb.Id));
        }

        // DELETE: api/Finances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinances(int id)
        {
            var finances = await _context.Finances.FindAsync(id);
            if (finances == null)
            {
                return NotFound();
            }

            _context.Finances.Remove(finances);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinancesExists(int id)
        {
            return _context.Finances.Any(e => e.Id == id);
        }
    }
}
