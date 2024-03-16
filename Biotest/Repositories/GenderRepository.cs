using Biotest.Model;
using Biotest.Context;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender> GetGenders(int id);
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

        public async Task<Gender>GetGenders(int id)
        {
            // LINQ
            return await _db.Gender.FirstOrDefaultAsync(u => u.GenderID == id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            throw new NotImplementedException();
        }

        public Gender CreateGender(string name)
        {
            Gender newGender = new Gender { 
                Name = name
            };
            _db.Gender.Add(newGender);
            _db.SaveChanges();
            return newGender;
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

