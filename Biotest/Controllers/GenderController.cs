using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenderController(IGenderService genderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            IEnumerable<Gender> genders = await genderService.GetGenders();
            return Ok(genders);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetGender(int id)
        {
            Gender? gender = await genderService.GetGender(id);
            if (gender == null) return NotFound();
            return Ok(gender);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGender([Required][MaxLength(30)] string Name)
        {
            var gender = await genderService.CreateGender(Name);
            return CreatedAtAction(nameof(GetGender), new { id = gender.GenderID }, gender);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGender([Required] int GenderID, [MaxLength(30)] string Name)
        {
            var updatedGender = await genderService.UpdateGender(GenderID, Name);
            return Ok(updatedGender);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var deletedGender = await genderService.DeleteGender(id);
            if (deletedGender == null) return NotFound();
            return Ok(deletedGender);
        }
    }
}
