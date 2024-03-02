using Biotest.Model;

namespace Biotest.Repositories
{

    public interface IPatientRepository
    {
        IEnumerable<Patient> GetPatients();
        Patient GetPatient(int id);
        Patient PutPatient(int id, Patient patient);
        Patient PostPatient(Patient patient);
        Patient DeletePatient(int id);
    }

    public class PatientRepository : IPatientRepository
    {
        public Patient DeletePatient(int id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatient(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatients()
        {
            throw new NotImplementedException();
        }

        public Patient PostPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Patient PutPatient(int id, Patient patient)
        {
            throw new NotImplementedException();
        }
    }


}
