using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;


namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenotypeController(IGenotypeService genotypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGenotypes()
        {
            IEnumerable<Genotype> genotypes = await genotypeService.GetGenotypes();
            return Ok(genotypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGenotype(int id)
        {
            Genotype? genotype = await genotypeService.GetGenotype(id);
            if (genotype == null) return NotFound();
            return Ok(genotype);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenotype(
            [Required][MaxLength(30)] string Name
        )
        {
            var genotype = await genotypeService.CreateGenotype(Name);
            return CreatedAtAction(nameof(GetGenotype), new { id = genotype.GenotypeID }, genotype);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenotype(
            [Required] int GenotypeID,
            [MaxLength(30)] string Name
        )
        {
            var updatedGenotype = await genotypeService.UpdateGenotype(GenotypeID, Name);
            return Ok(updatedGenotype);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGenotype(int id)
        {
            var deletedGenotype = await genotypeService.DeleteGenotype(id);
            if (deletedGenotype == null) return NotFound();
            return Ok(deletedGenotype);
        }
    }


}
