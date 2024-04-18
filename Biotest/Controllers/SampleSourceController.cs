using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SampleSourceController(ISampleSourceService sampleSourceService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSampleSources()
        {
            IEnumerable<SampleSource> sampleSources = await sampleSourceService.GetSampleSources();
            return Ok(sampleSources);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSampleSource(int id)
        {
            SampleSource? sampleSource = await sampleSourceService.GetSampleSource(id);
            if (sampleSource == null) return NotFound();
            return Ok(sampleSource);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSampleSource(
            [Required][MaxLength(30)] string Name
        )
        {
            var sampleSource = await sampleSourceService.CreateSampleSource(Name);
            return CreatedAtAction(nameof(GetSampleSource), new { id = sampleSource.SampleSourceID }, sampleSource);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSampleSource(
            [Required] int SampleSourceID,
            [MaxLength(30)] string? Name
        )
        {
            var updatedSampleSource = await sampleSourceService.UpdateSampleSource(SampleSourceID, Name);
            return Ok(updatedSampleSource);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSampleSource(int id)
        {
            var deletedSampleSource = await sampleSourceService.DeleteSampleSource(id);
            if (deletedSampleSource == null) return NotFound();
            return Ok(deletedSampleSource);
        }
    }
}
