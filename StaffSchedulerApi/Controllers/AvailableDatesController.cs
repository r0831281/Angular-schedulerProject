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
    public class AvailableDatesController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public AvailableDatesController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/AvailableDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AvailableDate>>> GetavailableDates()
        {
            return await _context.AvailableDates.ToListAsync();
        }

        // GET: api/AvailableDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AvailableDate>> GetAvailableDate(int id)
        {
            var availableDate = await _context.AvailableDates.FindAsync(id);

            if (availableDate == null)
            {
                return NotFound();
            }

            return availableDate;
        }

        // PUT: api/AvailableDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvailableDate(int id, AvailableDate availableDate)
        {
            if (id != availableDate.Id)
            {
                return BadRequest();
            }

            _context.Entry(availableDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvailableDateExists(id))
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

        // POST: api/AvailableDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AvailableDate>> PostAvailableDate(AvailableDate availableDate)
        {
            _context.AvailableDates.Add(availableDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvailableDate", new { id = availableDate.Id }, availableDate);
        }

        // DELETE: api/AvailableDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvailableDate(int id)
        {
            var availableDate = await _context.AvailableDates.FindAsync(id);
            if (availableDate == null)
            {
                return NotFound();
            }

            _context.AvailableDates.Remove(availableDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvailableDateExists(int id)
        {
            return _context.AvailableDates.Any(e => e.Id == id);
        }
    }
}
