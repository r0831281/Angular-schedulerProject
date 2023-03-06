using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffSchedulerApi.Data;
using StaffSchedulerApi.Models;

namespace StaffSchedulerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestedDatesController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public RequestedDatesController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/RequestedDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestedDate>>> GetrequestedDate()
        {
            return await _context.requestedDate.ToListAsync();
        }

        // GET: api/RequestedDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestedDate>> GetRequestedDate(int id)
        {
            var requestedDate = await _context.requestedDate.FindAsync(id);

            if (requestedDate == null)
            {
                return NotFound();
            }

            return requestedDate;
        }

        // PUT: api/RequestedDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestedDate(int id, RequestedDate requestedDate)
        {
            if (id != requestedDate.id)
            {
                return BadRequest();
            }

            _context.Entry(requestedDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestedDateExists(id))
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

        // POST: api/RequestedDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RequestedDate>> PostRequestedDate(RequestedDate requestedDate)
        {
            _context.requestedDate.Add(requestedDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestedDate", new { id = requestedDate.id }, requestedDate);
        }

        // DELETE: api/RequestedDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestedDate(int id)
        {
            var requestedDate = await _context.requestedDate.FindAsync(id);
            if (requestedDate == null)
            {
                return NotFound();
            }

            _context.requestedDate.Remove(requestedDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestedDateExists(int id)
        {
            return _context.requestedDate.Any(e => e.id == id);
        }
    }
}
