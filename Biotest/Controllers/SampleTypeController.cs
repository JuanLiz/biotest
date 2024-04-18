using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SampleTypeController(ISampleTypeService sampleTypeService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSampleTypes()
        {
            IEnumerable<SampleType> sampleTypes = await sampleTypeService.GetSampleTypes();
            return Ok(sampleTypes);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSampleType(int id)
        {
            SampleType? sampleType = await sampleTypeService.GetSampleType(id);
            if (sampleType == null) return NotFound();
            return Ok(sampleType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSampleType(
            [Required][MaxLength(30)] string Name
        )
        {
            var sampleType = await sampleTypeService.CreateSampleType(Name);
            return CreatedAtAction(nameof(GetSampleType), new { id = sampleType.SampleTypeID }, sampleType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSampleType(
            [Required] int SampleTypeID,
            [MaxLength(30)] string Name
        )
        {
            var updatedSampleType = await sampleTypeService.UpdateSampleType(SampleTypeID, Name);
            return Ok(updatedSampleType);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSampleType(int id)
        {
            var deletedSampleType = await sampleTypeService.DeleteSampleType(id);
            if (deletedSampleType == null) return NotFound();
            return Ok(deletedSampleType);
        }
    }
}
