using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{

    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> PostPatient(Patient patient);
        // TODO: Fix this bible
        Task<Patient> PutPatient(
            int id,
            string? name,
            string? lastName,
            DateOnly? birthDate,
            int? genderID,
            string? phone,
            string? address,
            string? email
            );
        Task<Patient?> DeletePatient(int id);
    }


    public class PatientService : IPatientService
    {

        private readonly PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Patient?> GetPatient(int id)
        {
            return await _patientRepository.GetPatient(id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _patientRepository.GetPatients();
        }

        public async Task<Patient> PostPatient(Patient patient)
        {
            return await _patientRepository.PostPatient(patient);
        }

        public async Task<Patient> PutPatient(
            int id,
            string? name,
            string? lastName,
            DateOnly? birthDate,
            int? genderID,
            string? phone,
            string? address,
            string? email
            )
        {
            Patient? newPatient = await _patientRepository.GetPatient(id);
            if (newPatient == null)
            {
                throw new Exception("Patient not found");
            }
            else
            {
                // Check nullability
                newPatient.Name = name ?? newPatient.Name;
                newPatient.LastName = lastName ?? newPatient.LastName;
                newPatient.BirthDate = birthDate ?? newPatient.BirthDate;
                newPatient.GenderID = genderID ?? newPatient.GenderID;
                newPatient.Phone = phone ?? newPatient.Phone;
                newPatient.Address = address ?? newPatient.Address;
                newPatient.Email = email ?? newPatient.Email;
                return await _patientRepository.PutPatient(id, newPatient);
            }
        }

        public async Task<Patient?> DeletePatient(int id)
        {
            return await _patientRepository.DeletePatient(id);
        }

    }

}