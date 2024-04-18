using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GeneticTestTypeController(IGeneticTestTypeService geneticTestTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGeneticTestTypes()
        {
            IEnumerable<GeneticTestType> geneticTestTypes = await geneticTestTypeService.GetGeneticTestTypes();
            return Ok(geneticTestTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGeneticTestType(int id)
        {
            GeneticTestType? geneticTestType = await geneticTestTypeService.GetGeneticTestType(id);
            if (geneticTestType == null) return NotFound();
            return Ok(geneticTestType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneticTestType(
            [Required][MaxLength(30)] string Name
        )
        {
            var geneticTestType = await geneticTestTypeService.CreateGeneticTestType(Name);
            return CreatedAtAction(nameof(GetGeneticTestType), new { id = geneticTestType.GeneticTestTypeID }, geneticTestType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeneticTestType(
            [Required] int GeneticTestTypeID,
            [MaxLength(30)] string Name
        )
        {
            var updatedGeneticTestType = await geneticTestTypeService.UpdateGeneticTestType(GeneticTestTypeID, Name);
            return Ok(updatedGeneticTestType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGeneticTestType(int id)
        {
            var deletedGeneticTestType = await geneticTestTypeService.DeleteGeneticTestType(id);
            if (deletedGeneticTestType == null) return NotFound();
            return Ok(deletedGeneticTestType);
        }
    }
}
