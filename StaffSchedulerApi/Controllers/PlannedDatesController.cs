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
    public class PlannedDatesController : ControllerBase
    {
        private readonly ScheduleContext _context;

        public PlannedDatesController(ScheduleContext context)
        {
            _context = context;
        }

        // GET: api/PlannedDates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlannedDate>>> GetplannedDates()
        {
            return await _context.PlannedDates.ToListAsync();
        }

        // GET: api/PlannedDates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlannedDate>> GetPlannedDate(int id)
        {
            var plannedDate = await _context.PlannedDates.FindAsync(id);

            if (plannedDate == null)
            {
                return NotFound();
            }

            return plannedDate;
        }

        // PUT: api/PlannedDates/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlannedDate(int id, PlannedDate plannedDate)
        {
            if (id != plannedDate.Id)
            {
                return BadRequest();
            }

            _context.Entry(plannedDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlannedDateExists(id))
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

        // POST: api/PlannedDates
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlannedDate>> PostPlannedDate(PlannedDate plannedDate)
        {
            _context.PlannedDates.Add(plannedDate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlannedDate", new { id = plannedDate.Id }, plannedDate);
        }

        // DELETE: api/PlannedDates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlannedDate(int id)
        {
            var plannedDate = await _context.PlannedDates.FindAsync(id);
            if (plannedDate == null)
            {
                return NotFound();
            }

            _context.PlannedDates.Remove(plannedDate);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlannedDateExists(int id)
        {
            return _context.PlannedDates.Any(e => e.Id == id);
        }
    }
}
