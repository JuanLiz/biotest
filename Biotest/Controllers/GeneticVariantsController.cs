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
    public class GeneticVariantsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneticVariantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneticVariants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneticVariant>>> GetGeneticVariant()
        {
            return await _context.GeneticVariant.ToListAsync();
        }

        // GET: api/GeneticVariants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneticVariant>> GetGeneticVariant(int id)
        {
            var geneticVariant = await _context.GeneticVariant.FindAsync(id);

            if (geneticVariant == null)
            {
                return NotFound();
            }

            return geneticVariant;
        }

        // PUT: api/GeneticVariants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneticVariant(int id, GeneticVariant geneticVariant)
        {
            if (id != geneticVariant.GeneticVariantID)
            {
                return BadRequest();
            }

            _context.Entry(geneticVariant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneticVariantExists(id))
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

        // POST: api/GeneticVariants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneticVariant>> PostGeneticVariant(GeneticVariant geneticVariant)
        {
            _context.GeneticVariant.Add(geneticVariant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneticVariant", new { id = geneticVariant.GeneticVariantID }, geneticVariant);
        }

        // DELETE: api/GeneticVariants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneticVariant(int id)
        {
            var geneticVariant = await _context.GeneticVariant.FindAsync(id);
            if (geneticVariant == null)
            {
                return NotFound();
            }

            _context.GeneticVariant.Remove(geneticVariant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneticVariantExists(int id)
        {
            return _context.GeneticVariant.Any(e => e.GeneticVariantID == id);
        }
    }
}
