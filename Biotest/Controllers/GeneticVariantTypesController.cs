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
    public class GeneticVariantTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneticVariantTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneticVariantTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneticVariantType>>> GetGeneticVariantType()
        {
            return await _context.GeneticVariantType.ToListAsync();
        }

        // GET: api/GeneticVariantTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneticVariantType>> GetGeneticVariantType(int id)
        {
            var geneticVariantType = await _context.GeneticVariantType.FindAsync(id);

            if (geneticVariantType == null)
            {
                return NotFound();
            }

            return geneticVariantType;
        }

        // PUT: api/GeneticVariantTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneticVariantType(int id, GeneticVariantType geneticVariantType)
        {
            if (id != geneticVariantType.GeneticVariantTypeID)
            {
                return BadRequest();
            }

            _context.Entry(geneticVariantType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneticVariantTypeExists(id))
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

        // POST: api/GeneticVariantTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneticVariantType>> PostGeneticVariantType(GeneticVariantType geneticVariantType)
        {
            _context.GeneticVariantType.Add(geneticVariantType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneticVariantType", new { id = geneticVariantType.GeneticVariantTypeID }, geneticVariantType);
        }

        // DELETE: api/GeneticVariantTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneticVariantType(int id)
        {
            var geneticVariantType = await _context.GeneticVariantType.FindAsync(id);
            if (geneticVariantType == null)
            {
                return NotFound();
            }

            _context.GeneticVariantType.Remove(geneticVariantType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneticVariantTypeExists(int id)
        {
            return _context.GeneticVariantType.Any(e => e.GeneticVariantTypeID == id);
        }
    }
}
