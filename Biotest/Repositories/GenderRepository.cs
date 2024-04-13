using Biotest.Model;
using Biotest.Context;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender?> GetGender(int id);
        Task<Gender> PutGender(int id, Gender gender);
        Task<Gender> PostGender(Gender gender);
        Task<Gender?> DeleteGender(int id);
        
    }

    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDbContext _db;

        public GenderRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Gender?> GetGender(int id)
        {
            // Simplified function to get a patient by id
            return await _db.Gender.FindAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            // Simplified function to get all patients
            return await _db.Gender.ToListAsync();
        }

        public async Task<Gender> PostGender(Gender gender)
        {
            // Simplified function to add a patient
            _db.Gender.Add(gender);
            await _db.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender> PutGender(int id, Gender gender)
        {
            // Simplified function to update a patient
            _db.Entry(gender).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return gender;
        }

        public Task<Gender?> DeleteGender(int id)
        {
            // Change boolean state
            throw new NotImplementedException();
        }



    }
  
}

