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
    public class AnalysisTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnalysisTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AnalysisTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysisType>>> GetAnalysisType()
        {
            return await _context.AnalysisType.ToListAsync();
        }

        // GET: api/AnalysisTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysisType>> GetAnalysisType(int id)
        {
            var analysisType = await _context.AnalysisType.FindAsync(id);

            if (analysisType == null)
            {
                return NotFound();
            }

            return analysisType;
        }

        // PUT: api/AnalysisTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysisType(int id, AnalysisType analysisType)
        {
            if (id != analysisType.AnalysisTypeID)
            {
                return BadRequest();
            }

            _context.Entry(analysisType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysisTypeExists(id))
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

        // POST: api/AnalysisTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnalysisType>> PostAnalysisType(AnalysisType analysisType)
        {
            _context.AnalysisType.Add(analysisType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysisType", new { id = analysisType.AnalysisTypeID }, analysisType);
        }

        // DELETE: api/AnalysisTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysisType(int id)
        {
            var analysisType = await _context.AnalysisType.FindAsync(id);
            if (analysisType == null)
            {
                return NotFound();
            }

            _context.AnalysisType.Remove(analysisType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysisTypeExists(int id)
        {
            return _context.AnalysisType.Any(e => e.AnalysisTypeID == id);
        }
    }
}
