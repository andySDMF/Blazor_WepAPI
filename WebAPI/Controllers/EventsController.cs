using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EventsController(ApplicationDBContext context) 
        {
            dbContext = context;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            var events = dbContext.Events.OrderByDescending(x => x.Id).ToList();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(int id)
        {
            var evt = dbContext.Events.Find(id);

            if (evt == null)
            {   
                return NotFound();
            }

            return Ok(evt);
        }

        [HttpPost]
        public IActionResult CreateEvent(EventDto eventDto)
        {
            var evt = new Event()
            {
                Name = eventDto.Name,
                Description = eventDto.Description,
                Start = eventDto.Start,
                End = eventDto.End,
                AllDay = eventDto.AllDay,
                CreatedAt = DateTime.Now
            };

            dbContext.Events.Add(evt);
            dbContext.SaveChanges();

            return Ok(evt);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEvent(int id, EventDto eventDto)
        {
            var evt = dbContext.Events.Find(id);

            if (evt == null)
            {
                return NotFound();
            }

            evt.Name = eventDto.Name;
            evt.Description = eventDto.Description;
            evt.Start = eventDto.Start;
            evt.End = eventDto.End;
            evt.AllDay = eventDto.AllDay;

            dbContext.SaveChanges();

            return Ok(evt);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var evt = dbContext.Events.Find(id);

            if (evt == null)
            {
                return NotFound();
            }

            dbContext.Events.Remove(evt);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}
