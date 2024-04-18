using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GeneticTestController(IGeneticTestService geneticTestService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGeneticTests()
        {
            IEnumerable<GeneticTest> geneticTests = await geneticTestService.GetGeneticTests();
            return Ok(geneticTests);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGeneticTest(int id)
        {
            GeneticTest? geneticTest = await geneticTestService.GetGeneticTest(id);
            if (geneticTest == null) return NotFound();
            return Ok(geneticTest);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGeneticTest(
            [Required] int GeneticTestTypeID,
            [Required] int SampleID,
            [Required] int EmployeeID,
            [Required] DateTime Date,
            [Required][MaxLength(500)] string Results

        )
        {
            var geneticTest = await geneticTestService.CreateGeneticTest(GeneticTestTypeID, SampleID, EmployeeID, Date, Results);
            return CreatedAtAction(nameof(GetGeneticTest), new { id = geneticTest.GeneticTestID }, geneticTest);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGeneticTest(
            [Required] int GeneticTestID,
            int? GeneticTestTypeID,
            int? SampleID,
            int? EmployeeID,
            DateTime? Date,
            [MaxLength(500)] string? Results
        )
        {
            var updatedGeneticTest = await geneticTestService.UpdateGeneticTest(GeneticTestID, GeneticTestTypeID, SampleID, EmployeeID, Date, Results);
            return Ok(updatedGeneticTest);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGeneticTest(int id)
        {
            var deletedGeneticTest = await geneticTestService.DeleteGeneticTest(id);
            if (deletedGeneticTest == null) return NotFound();
            return Ok(deletedGeneticTest);
        }
    }
}
