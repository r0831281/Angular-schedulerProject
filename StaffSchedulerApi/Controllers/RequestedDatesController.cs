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
        public async Task<ActionResult<IEnumerable<RequestedDate>>> GetRequestedDate()
        {
            return await _context.RequestedDate.ToListAsync();
        }

        // GET: api/RequestedDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestedDate>> GetRequestedDate(int id)
        {
            var requestedDate = await _context.RequestedDate.FindAsync(id);

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
            if (id != requestedDate.Id)
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
            _context.RequestedDate.Add(requestedDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestedDate", new { id = requestedDate.Id }, requestedDate);
        }

        // DELETE: api/RequestedDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestedDate(int id)
        {
            var requestedDate = await _context.RequestedDate.FindAsync(id);
            if (requestedDate == null)
            {
                return NotFound();
            }

            _context.RequestedDate.Remove(requestedDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestedDateExists(int id)
        {
            return _context.RequestedDate.Any(e => e.Id == id);
        }
    }
}
