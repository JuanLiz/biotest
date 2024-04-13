using Biotest.Model;
using Biotest.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biotest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _patientRepository.GetPatients();
            return Ok(patients);
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {
            var patient = await _patientRepository.GetPatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> PostPatient(Patient patient)
        {
            var newPatient = await _patientRepository.PostPatient(patient);
            return CreatedAtAction(nameof(GetPatient), new { id = newPatient.PatientID }, newPatient);
        }

        [HttpPut]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            var newPatient = await _patientRepository.PutPatient(id, patient);
            return Ok(newPatient);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _patientRepository.DeletePatient(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

    }
}
