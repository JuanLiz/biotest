using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{

    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> CreatePatient(Patient patient);
        Task<Patient> UpdatePatient(Patient patient);
        Task<Patient?> DeletePatient(int id);
    }

    public class PatientRepository(ApplicationDbContext db) : IPatientRepository
    {
        public async Task<Patient?> GetPatient(int id)
        {
            return await db.Patient.FindAsync(id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await db.Patient.ToListAsync();
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            db.Patient.Add(patient);
            await db.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdatePatient(Patient patient)
        {
            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> DeletePatient(int id)
        {
            Patient? patient = await db.Patient.FindAsync(id);
            if (patient == null) return patient;
            patient.IsActive = false;
            db.Entry(patient).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return patient;
        }

    }

}
