using System.ComponentModel.DataAnnotations;
using Biotest.Model;
using Biotest.Services;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            IEnumerable<Patient> patients = await patientService.GetPatients();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            Patient? patient = await patientService.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(
            [Required]
            [MaxLength(30)]
            string Name,
            [Required]
            [MaxLength(30)]
            string LastName,
            [Required]
            DateOnly BirthDate,
            [Required]
            int GenderID,
            [Required]
            [Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string Phone,
            [Required]
            [MaxLength(50)]
            string Address,
            [Required]
            [MaxLength(320)]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            string Email
        )
        {
            var newPatient = await patientService.CreatePatient(Name, LastName, BirthDate, GenderID, Phone, Address, Email);
            return CreatedAtAction(nameof(GetPatient), new { id = newPatient.PatientID }, newPatient);
        }

        [HttpUpdate]
        public async Task<IActionResult> UpdatePatient(
            [Required]
            int PatientID,
            [MaxLength(30)]
            string? Name,
            [MaxLength(30)]
            string? LastName,
            DateOnly? BirthDate,
            int? GenderID,
            [Length(10, 10, ErrorMessage = "Phone number must be 10 digits")]
            [Phone(ErrorMessage = "Invalid phone number")]
            string? Phone,
            [MaxLength(50)]
            string? Address,
            [MaxLength(320)]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            string? Email
            )
        {
            var newPatient = await patientService.UpdatePatient(PatientID, Name, LastName, BirthDate, GenderID, Phone, Address, Email);
            return Ok(newPatient);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await patientService.DeletePatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

    }
}
