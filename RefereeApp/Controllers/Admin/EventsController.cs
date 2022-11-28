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
    public class EventsController : Controller
    {

        private readonly AuthenticationContext _context;

        public EventsController(AuthenticationContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CallendarEvent>>> Get(int page = 0, int pageSize = 10)
        {
            IList<CallendarEvent> result = new List<CallendarEvent>();
            var authUser = HttpContext.User;
            var userId = authUser.Claims.FirstOrDefault(claim => claim.Type == "UserID");

           

            if (userId == null) 
                return NotFound("Nie znaleziono użytkownika");

            result = await _context.CallendarEvents.Skip(page * pageSize).Take(pageSize).ToListAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<CallendarEvent>>> AddEvent(CreateEventRequestAdmin newEvent)
        {
            var user = _context.ApplicationUsers.FirstOrDefault(user => user.Id == newEvent.UserId);
            if (user == null) return NotFound("Nie znaleziono użytkownika");
            
            var eventDb = new CallendarEvent
            {
                name = newEvent.Name,
                startDate = newEvent.StartDate,
                endDate = newEvent.EndDate,
                User = user
            };
            _context.CallendarEvents.Add(eventDb);
            await _context.SaveChangesAsync();

            return Ok(new CreateEventResponse(eventDb.id));
        }

        [HttpPut]
        public async Task<ActionResult<List<CallendarEvent>>> UpdateEvent(CallendarEvent request)
        {
            var _event = await _context.CallendarEvents.FindAsync(request.id);
            if (_event == null)
                return BadRequest("Event not found");

            _event.name = request.name;
            _event.startDate = request.startDate;
            _event.endDate = request.endDate;
            _event.allDay = request.allDay;

            await _context.SaveChangesAsync();

            return Ok(await _context.CallendarEvents.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<CallendarEvent>>> Delete(int id)
        {
            var _event = await _context.CallendarEvents.FindAsync(id);
            if (_event == null)
                return BadRequest("Event not found");

            _context.CallendarEvents.Remove(_event);
            await _context.SaveChangesAsync();

            return Ok(await _context.CallendarEvents.ToListAsync());
        }
    }
}
