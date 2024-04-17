using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetPatients();
        Task<Patient?> GetPatient(int id);
        Task<Patient> CreatePatient(
            string Name,
            string LastName,
            DateOnly BirthDate,
            int GenderID,
            string Phone,
            string Address,
            string Email
            );
        Task<Patient> UpdatePatient(
            int PatientID,
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


    public class PatientService(IPatientRepository patientRepository) : IPatientService
    {
        public async Task<Patient?> GetPatient(int id)
        {
            return await patientRepository.GetPatient(id);
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await patientRepository.GetPatients();
        }

        public async Task<Patient> CreatePatient(
            string Name,
            string LastName,
            DateOnly BirthDate,
            int GenderID,
            string Phone,
            string Address,
            string Email
            )
        {
            return await patientRepository.CreatePatient(new Patient
            {
                Name = Name,
                LastName = LastName,
                BirthDate = BirthDate,
                GenderID = GenderID,
                Phone = Phone,
                Address = Address,
                Email = Email
            });
        }

        public async Task<Patient> UpdatePatient(
            int PatientID,
            string? name,
            string? lastName,
            DateOnly? birthDate,
            int? genderID,
            string? phone,
            string? address,
            string? email
            )
        {
            Patient? newPatient = await patientRepository.GetPatient(PatientID);
            if (newPatient == null) throw new Exception("Patient not found");

            // Check nullability. Replace only filled fields
            newPatient.Name = name ?? newPatient.Name;
            newPatient.LastName = lastName ?? newPatient.LastName;
            newPatient.BirthDate = birthDate ?? newPatient.BirthDate;
            newPatient.GenderID = genderID ?? newPatient.GenderID;
            newPatient.Phone = phone ?? newPatient.Phone;
            newPatient.Address = address ?? newPatient.Address;
            newPatient.Email = email ?? newPatient.Email;
            return await patientRepository.UpdatePatient(newPatient);
        }

        public async Task<Patient?> DeletePatient(int id)
        {
            return await patientRepository.DeletePatient(id);
        }

    }

}