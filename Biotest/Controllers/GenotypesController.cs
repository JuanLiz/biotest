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
    public class GenotypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenotypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Genotypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genotype>>> GetGenotype()
        {
            return await _context.Genotype.ToListAsync();
        }

        // GET: api/Genotypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genotype>> GetGenotype(int id)
        {
            var genotype = await _context.Genotype.FindAsync(id);

            if (genotype == null)
            {
                return NotFound();
            }

            return genotype;
        }

        // PUT: api/Genotypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenotype(int id, Genotype genotype)
        {
            if (id != genotype.GenotypeID)
            {
                return BadRequest();
            }

            _context.Entry(genotype).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenotypeExists(id))
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

        // POST: api/Genotypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genotype>> PostGenotype(Genotype genotype)
        {
            _context.Genotype.Add(genotype);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenotype", new { id = genotype.GenotypeID }, genotype);
        }

        // DELETE: api/Genotypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenotype(int id)
        {
            var genotype = await _context.Genotype.FindAsync(id);
            if (genotype == null)
            {
                return NotFound();
            }

            _context.Genotype.Remove(genotype);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenotypeExists(int id)
        {
            return _context.Genotype.Any(e => e.GenotypeID == id);
        }
    }
}
