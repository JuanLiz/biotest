using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{

    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> PostPatient(Patient patient);
        Task<Patient> PutPatient(int id, Patient patient);
        Task<Patient?> DeletePatient(int id);
    }

    public class PatientRepository : IPatientRepository
    {

        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Patient?> GetPatient(int id)
        {
            // Simplified function to get a patient by id
            return await _db.Patient.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            // Simplified function to get all patients
            return await _db.Patient.ToListAsync();
        }

        public async Task<Patient> PostPatient(Patient patient)
        {
            // Simplified function to add a patient
            _db.Patient.Add(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> PutPatient(int id, Patient patient)
        {
            // Simplified function to update a patient
            _db.Entry(patient).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return patient;
        }

        public Task<Patient?> DeletePatient(int id)
        {
            // Change boolean state
            throw new NotImplementedException();
        }
        
    }

}
