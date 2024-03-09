using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGenderRepository
    {
           IEnumerable<Gender> GetGenders();
        Gender GetGender(int id);
        Gender PutGender(int id, Gender gender);
        Gender PostGender(Gender gender);
        Gender DeleteGender(int id);
    }

    public class GenderRepository : IGenderRepository
    {
           public Gender GetGender(int id)
        {
               throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetGenders()
        {
                throw new NotImplementedException();
        }

        public Gender PostGender(Gender gender)
        {
                throw new NotImplementedException();
        }

        public Gender PutGender(int id, Gender gender)
        {
                throw new NotImplementedException();
        }   
        public Gender DeleteGender(int id)
        {
                throw new NotImplementedException();
        }
    }
  
}

