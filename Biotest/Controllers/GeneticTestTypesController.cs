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
    public class GeneticTestTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneticTestTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneticTestTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneticTestType>>> GetGeneticTestType()
        {
            return await _context.GeneticTestType.ToListAsync();
        }

        // GET: api/GeneticTestTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneticTestType>> GetGeneticTestType(int id)
        {
            var geneticTestType = await _context.GeneticTestType.FindAsync(id);

            if (geneticTestType == null)
            {
                return NotFound();
            }

            return geneticTestType;
        }

        // PUT: api/GeneticTestTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneticTestType(int id, GeneticTestType geneticTestType)
        {
            if (id != geneticTestType.GeneticTestTypeID)
            {
                return BadRequest();
            }

            _context.Entry(geneticTestType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneticTestTypeExists(id))
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

        // POST: api/GeneticTestTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneticTestType>> PostGeneticTestType(GeneticTestType geneticTestType)
        {
            _context.GeneticTestType.Add(geneticTestType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneticTestType", new { id = geneticTestType.GeneticTestTypeID }, geneticTestType);
        }

        // DELETE: api/GeneticTestTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneticTestType(int id)
        {
            var geneticTestType = await _context.GeneticTestType.FindAsync(id);
            if (geneticTestType == null)
            {
                return NotFound();
            }

            _context.GeneticTestType.Remove(geneticTestType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneticTestTypeExists(int id)
        {
            return _context.GeneticTestType.Any(e => e.GeneticTestTypeID == id);
        }
    }
}
