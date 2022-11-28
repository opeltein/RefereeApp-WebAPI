using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RefereeApp.Models;
using RefereeApp.Models.ApiModels;
using RefereeApp.Utils;
using WebAPI.Models;

namespace RefereeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Referee")]
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
            result = await _context.CallendarEvents.Where(calendarEvent => calendarEvent.User != null && calendarEvent.User.Id == HttpContext.GetUserId()).Skip(page * pageSize).Take(pageSize).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CallendarEvent>> Get(int id)
        {
            var singleEvent = await _context.CallendarEvents.FindAsync(id);
            if (singleEvent == null)
                return BadRequest("Event not found");
            return Ok(singleEvent);
        }

        [HttpPost]
        public async Task<ActionResult<List<CallendarEvent>>> AddEvent(CreateEventRequest newEvent)
        {
            var userId = HttpContext.GetUserId();

            
            var user = await _context.ApplicationUsers.FirstAsync(user => user.Id == userId);
            //I do it - Tomek : Walnąć customowym wyjątkiem
            if (user is null)
                return NotFound("Nie znaleziono takiego użytkownika");

            var eventDb = new CallendarEvent

            {
                startDate = newEvent.StartDate,
                endDate = newEvent.EndDate,
                name = newEvent.Name,
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
