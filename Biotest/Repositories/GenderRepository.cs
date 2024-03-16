using Biotest.Model;
using Biotest.Context;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenderRepository
    {
           IEnumerable<Gender> GetGenders();
        Gender GetGender(int id);
        Gender PutGender(int id, Gender gender);
        Gender PostGender(Gender gender);
        Gender DeleteGender(int id);
        Gender CreateGender(string name);
    }

    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _db;

        public GenderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Gender> GetGender(int id)
        {
            // LINQ
            return await _db.Gender.FirstOrDefaultAsync(u => u.GenderID == id);
        }


        public Gender CreateGender(string name)
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

        Gender IGenderRepository.GetGender(int id)
        {
            throw new NotImplementedException();
        }
    }
  
}

