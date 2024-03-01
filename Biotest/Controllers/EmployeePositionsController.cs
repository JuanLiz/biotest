using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biotest.Context;
using Biotest.Model;

namespace Biotest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeePositionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeePositionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EmployeePositions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeePosition>>> GetEmployeePosition()
        {
            return await _context.EmployeePosition.ToListAsync();
        }

        // GET: api/EmployeePositions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeePosition>> GetEmployeePosition(int id)
        {
            var employeePosition = await _context.EmployeePosition.FindAsync(id);

            if (employeePosition == null)
            {
                return NotFound();
            }

            return employeePosition;
        }

        // PUT: api/EmployeePositions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeePosition(int id, EmployeePosition employeePosition)
        {
            if (id != employeePosition.EmployeePositionID)
            {
                return BadRequest();
            }

            _context.Entry(employeePosition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeePositionExists(id))
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

        // POST: api/EmployeePositions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeePosition>> PostEmployeePosition(EmployeePosition employeePosition)
        {
            _context.EmployeePosition.Add(employeePosition);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeePosition", new { id = employeePosition.EmployeePositionID }, employeePosition);
        }

        // DELETE: api/EmployeePositions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeePosition(int id)
        {
            var employeePosition = await _context.EmployeePosition.FindAsync(id);
            if (employeePosition == null)
            {
                return NotFound();
            }

            _context.EmployeePosition.Remove(employeePosition);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeePositionExists(int id)
        {
            return _context.EmployeePosition.Any(e => e.EmployeePositionID == id);
        }
    }
}
