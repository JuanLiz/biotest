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
    public class PredictedEffectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PredictedEffectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PredictedEffects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PredictedEffect>>> GetPredictedEffect()
        {
            return await _context.PredictedEffect.ToListAsync();
        }

        // GET: api/PredictedEffects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PredictedEffect>> GetPredictedEffect(int id)
        {
            var predictedEffect = await _context.PredictedEffect.FindAsync(id);

            if (predictedEffect == null)
            {
                return NotFound();
            }

            return predictedEffect;
        }

        // PUT: api/PredictedEffects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPredictedEffect(int id, PredictedEffect predictedEffect)
        {
            if (id != predictedEffect.PredictedEffectID)
            {
                return BadRequest();
            }

            _context.Entry(predictedEffect).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredictedEffectExists(id))
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

        // POST: api/PredictedEffects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PredictedEffect>> PostPredictedEffect(PredictedEffect predictedEffect)
        {
            _context.PredictedEffect.Add(predictedEffect);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPredictedEffect", new { id = predictedEffect.PredictedEffectID }, predictedEffect);
        }

        // DELETE: api/PredictedEffects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePredictedEffect(int id)
        {
            var predictedEffect = await _context.PredictedEffect.FindAsync(id);
            if (predictedEffect == null)
            {
                return NotFound();
            }

            _context.PredictedEffect.Remove(predictedEffect);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PredictedEffectExists(int id)
        {
            return _context.PredictedEffect.Any(e => e.PredictedEffectID == id);
        }
    }
}
