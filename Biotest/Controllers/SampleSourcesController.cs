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
    public class SampleSourcesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SampleSourcesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SampleSources
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleSource>>> GetSampleSource()
        {
            return await _context.SampleSource.ToListAsync();
        }

        // GET: api/SampleSources/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleSource>> GetSampleSource(int id)
        {
            var sampleSource = await _context.SampleSource.FindAsync(id);

            if (sampleSource == null)
            {
                return NotFound();
            }

            return sampleSource;
        }

        // PUT: api/SampleSources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleSource(int id, SampleSource sampleSource)
        {
            if (id != sampleSource.SampleSourceID)
            {
                return BadRequest();
            }

            _context.Entry(sampleSource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleSourceExists(id))
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

        // POST: api/SampleSources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SampleSource>> PostSampleSource(SampleSource sampleSource)
        {
            _context.SampleSource.Add(sampleSource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleSource", new { id = sampleSource.SampleSourceID }, sampleSource);
        }

        // DELETE: api/SampleSources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSampleSource(int id)
        {
            var sampleSource = await _context.SampleSource.FindAsync(id);
            if (sampleSource == null)
            {
                return NotFound();
            }

            _context.SampleSource.Remove(sampleSource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SampleSourceExists(int id)
        {
            return _context.SampleSource.Any(e => e.SampleSourceID == id);
        }
    }
}
