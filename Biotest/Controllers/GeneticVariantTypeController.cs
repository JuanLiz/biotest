using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GeneticVariantTypeController(IGeneticVariantTypeService geneticVariantTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGeneticVariantTypes()
        {
            IEnumerable<GeneticVariantType> geneticVariantTypes = await geneticVariantTypeService.GetGeneticVariantTypes();
            return Ok(geneticVariantTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGeneticVariantType(int id)
        {
            GeneticVariantType? geneticVariantType = await geneticVariantTypeService.GetGeneticVariantType(id);
            if (geneticVariantType == null) return NotFound();
            return Ok(geneticVariantType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneticVariantType(
            [Required][MaxLength(30)] string Name
        )
        {
            var geneticVariantType = await geneticVariantTypeService.CreateGeneticVariantType(Name);
            return CreatedAtAction(nameof(GetGeneticVariantType), new { id = geneticVariantType.GeneticVariantTypeID }, geneticVariantType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeneticVariantType(
            [Required] int GeneticVariantTypeID,
            [MaxLength(30)] string Name
        )
        {
            var updatedGeneticVariantType = await geneticVariantTypeService.UpdateGeneticVariantType(GeneticVariantTypeID, Name);
            return Ok(updatedGeneticVariantType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGeneticVariantType(int id)
        {
            var deletedGeneticVariantType = await geneticVariantTypeService.DeleteGeneticVariantType(id);
            if (deletedGeneticVariantType == null) return NotFound();
            return Ok(deletedGeneticVariantType);
        }
    }
}
