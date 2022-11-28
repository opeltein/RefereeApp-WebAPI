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
            result = await _context.Finances.Where(finances => finances.User != null && finances.User.Id == HttpContext.GetUserId()).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }

        // GET: api/Finances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Finances>> GetFinances(int id)
        {
            var finances = await _context.Finances.FindAsync(id);

            if (finances == null)
            {
                return NotFound();
            }

            return finances;
        }

        private bool FinancesExists(int id)
        {
            return _context.Finances.Any(e => e.Id == id);
        }
    }
}
