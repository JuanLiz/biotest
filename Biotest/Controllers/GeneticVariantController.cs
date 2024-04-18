using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class GeneticVariantController(IGeneticVariantService geneticVariantService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGeneticVariants()
        {
            IEnumerable<GeneticVariant> geneticVariants = await geneticVariantService.GetGeneticVariants();
            return Ok(geneticVariants);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGeneticVariant(int id)
        {
            GeneticVariant? geneticVariant = await geneticVariantService.GetGeneticVariant(id);
            if (geneticVariant == null) return NotFound();
            return Ok(geneticVariant);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneticVariant(
            [Required] int GeneticVariantTypeID,
            [Required] int AnalysisID,
            [Required] int GenotypeID,
            [Required] string Location,
            [Required][MaxLength(30)] int PredictedEffectID
        )
        {
            var geneticVariant = await geneticVariantService.CreateGeneticVariant(GeneticVariantTypeID, AnalysisID,
                GenotypeID, Location, PredictedEffectID);
            return CreatedAtAction(nameof(GetGeneticVariant), new { id = geneticVariant.GeneticVariantID },
                geneticVariant);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeneticVariant(
            [Required] int GeneticVariantID,
            int GeneticVariantTypeID,
            int AnalysisID,
            int GenotypeID,
            string Location,
            [MaxLength(30)] int PredictedEffectID
        )
        {
            var updatedGeneticVariant = await geneticVariantService.UpdateGeneticVariant(GeneticVariantID,
                               GeneticVariantTypeID, AnalysisID, GenotypeID, Location, PredictedEffectID);
            return Ok(updatedGeneticVariant);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGeneticVariant(int id)
        {
            var deletedGeneticVariant = await geneticVariantService.DeleteGeneticVariant(id);
            if (deletedGeneticVariant == null) return NotFound();
            return Ok(deletedGeneticVariant);
        }


    }
}