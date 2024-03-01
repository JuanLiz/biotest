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
    public class GeneticTestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneticTestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneticTests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneticTest>>> GetGeneticTest()
        {
            return await _context.GeneticTest.ToListAsync();
        }

        // GET: api/GeneticTests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneticTest>> GetGeneticTest(int id)
        {
            var geneticTest = await _context.GeneticTest.FindAsync(id);

            if (geneticTest == null)
            {
                return NotFound();
            }

            return geneticTest;
        }

        // PUT: api/GeneticTests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneticTest(int id, GeneticTest geneticTest)
        {
            if (id != geneticTest.GeneticTestID)
            {
                return BadRequest();
            }

            _context.Entry(geneticTest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeneticTestExists(id))
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

        // POST: api/GeneticTests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneticTest>> PostGeneticTest(GeneticTest geneticTest)
        {
            _context.GeneticTest.Add(geneticTest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeneticTest", new { id = geneticTest.GeneticTestID }, geneticTest);
        }

        // DELETE: api/GeneticTests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneticTest(int id)
        {
            var geneticTest = await _context.GeneticTest.FindAsync(id);
            if (geneticTest == null)
            {
                return NotFound();
            }

            _context.GeneticTest.Remove(geneticTest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeneticTestExists(int id)
        {
            return _context.GeneticTest.Any(e => e.GeneticTestID == id);
        }
    }
}
