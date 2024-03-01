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
    public class AnalysesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnalysesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Analyses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analysis>>> GetAnalysis()
        {
            return await _context.Analysis.ToListAsync();
        }

        // GET: api/Analyses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analysis>> GetAnalysis(int id)
        {
            var analysis = await _context.Analysis.FindAsync(id);

            if (analysis == null)
            {
                return NotFound();
            }

            return analysis;
        }

        // PUT: api/Analyses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysis(int id, Analysis analysis)
        {
            if (id != analysis.AnalysisID)
            {
                return BadRequest();
            }

            _context.Entry(analysis).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysisExists(id))
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

        // POST: api/Analyses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Analysis>> PostAnalysis(Analysis analysis)
        {
            _context.Analysis.Add(analysis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysis", new { id = analysis.AnalysisID }, analysis);
        }

        // DELETE: api/Analyses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysis(int id)
        {
            var analysis = await _context.Analysis.FindAsync(id);
            if (analysis == null)
            {
                return NotFound();
            }

            _context.Analysis.Remove(analysis);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysisExists(int id)
        {
            return _context.Analysis.Any(e => e.AnalysisID == id);
        }
    }
}
