using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController(ISampleService sampleService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSamples()
        {
            IEnumerable<Sample> samples = await sampleService.GetSamples();
            return Ok(samples);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSample(int id)
        {
            Sample? sample = await sampleService.GetSample(id);
            if (sample == null) return NotFound();
            return Ok(sample);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSample(
            [Required] int PatientID,
            [Required] DateTime Date,
            [Required] int SampleTypeID,
            [Required] int SampleSourceID
        )
        {
            var sample = await sampleService.CreateSample(PatientID, Date, SampleTypeID, SampleSourceID);
            return CreatedAtAction(nameof(GetSample), new { id = sample.SampleID }, sample);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSample(
            [Required] int SampleID,
            int PatientID,
            DateTime Date,
            int SampleTypeID,
            int SampleSourceID
        )
        {
            var updatedSample = await sampleService.UpdateSample(SampleID, PatientID, Date, SampleTypeID, SampleSourceID);
            return Ok(updatedSample);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSample(int id)
        {
            var deletedSample = await sampleService.DeleteSample(id);
            if (deletedSample == null) return NotFound();
            return Ok(deletedSample);
        }
    }
}
}
