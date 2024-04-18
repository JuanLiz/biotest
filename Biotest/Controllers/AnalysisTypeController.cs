using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisTypeController(IAnalysisTypeService analysisTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAnalysisTypes()
        {
            IEnumerable<AnalysisType> analysisTypes = await analysisTypeService.GetAnalysisTypes();
            return Ok(analysisTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAnalysisType(int id)
        {
            AnalysisType? analysisType = await analysisTypeService.GetAnalysisType(id);
            if (analysisType == null)
            {
                return NotFound();
            }
            return Ok(analysisType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnalysisType(
            [Required][MaxLength(50)] string Name
        )
        {
            var analysisType = await analysisTypeService.CreateAnalysisType(Name);
            return CreatedAtAction(nameof(GetAnalysisType), new { id = analysisType.AnalysisTypeID }, analysisType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnalysisType(
            [Required] int AnalysisTypeID,
            [MaxLength(50)] string Name
        )
        {
            var updatedAnalysisType = await analysisTypeService.UpdateAnalysisType(AnalysisTypeID, Name);
            return Ok(updatedAnalysisType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAnalysisType(int id)
        {
            var deletedAnalysisType = await analysisTypeService.DeleteAnalysisType(id);
            if (deletedAnalysisType == null) return NotFound();
            return Ok(deletedAnalysisType);
        }
    }
}
