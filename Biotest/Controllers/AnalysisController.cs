using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController(IAnalysisService analysisService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAnalyses()
        {
            IEnumerable<Analysis> analyses = await analysisService.GetAnalyses();
            return Ok(analyses);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAnalysis(int id)
        {
            Analysis? analysis = await analysisService.GetAnalysis(id);
            if (analysis == null)
            {
                return NotFound();
            }
            return Ok(analysis);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnalysis(
            [Required] int AnalysisTypeID,
            [Required] int GeneticTestID,
            [Required] DateTime Date,
            [Required][MaxLength(50)] string Method,
            [Required][MaxLength(500)] string Results
        )
        {
            var analysis = await analysisService.CreateAnalysis(AnalysisTypeID, GeneticTestID, Date, Method, Results);
            return CreatedAtAction(nameof(GetAnalysis), new { id = analysis.AnalysisID }, analysis);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnalysis(
            [Required] int AnalysisID,
            int AnalysisTypeID,
            int GeneticTestID,
            DateTime Date,
            [MaxLength(50)] string Method,
            [MaxLength(500)] string Results
        )
        {
            var updatedAnalysis = await analysisService.UpdateAnalysis(AnalysisID, AnalysisTypeID, GeneticTestID, Date, Method, Results);
            return Ok(updatedAnalysis);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAnalysis(int id)
        {
            var deletedAnalysis = await analysisService.DeleteAnalysis(id);
            if (deletedAnalysis == null) return NotFound();
            return Ok();
        }

    }
}
