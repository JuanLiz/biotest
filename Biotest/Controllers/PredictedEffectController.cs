using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PredictedEffectController(IPredictedEffectService predictedEffectService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPredictedEffects()
        {
            IEnumerable<PredictedEffect> predictedEffects = await predictedEffectService.GetPredictedEffects();
            return Ok(predictedEffects);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPredictedEffect(int id)
        {
            PredictedEffect? predictedEffect = await predictedEffectService.GetPredictedEffect(id);
            if (predictedEffect == null) return NotFound();
            return Ok(predictedEffect);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePredictedEffect(
            [Required][MaxLength(30)] string Name
        )
        {
            var predictedEffect = await predictedEffectService.CreatePredictedEffect(Name);
            return CreatedAtAction(nameof(GetPredictedEffect), new { id = predictedEffect.PredictedEffectID }, predictedEffect);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePredictedEffect(
            [Required] int PredictedEffectID,
            [MaxLength(30)] string Name
        )
        {
            var updatedPredictedEffect = await predictedEffectService.UpdatePredictedEffect(PredictedEffectID, Name);
            return Ok(updatedPredictedEffect);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePredictedEffect(int id)
        {
            var deletedPredictedEffect = await predictedEffectService.DeletePredictedEffect(id);
            if (deletedPredictedEffect == null) return NotFound();
            return Ok(deletedPredictedEffect);
        }
    }
}
