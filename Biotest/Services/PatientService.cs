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
        Task<Patient> PutPatient(int id, Patient patient);
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

        public async Task<Patient> PutPatient(int id, Patient patient)
        {
            return await _patientRepository.PutPatient(id, patient);
        }

        public async Task<Patient?> DeletePatient(int id)
        {
            return await _patientRepository.DeletePatient(id);
        }
        
    }

}