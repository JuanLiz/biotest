using Biotest.Model;
using Biotest.Context;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender?> GetGender(int id);
        Task<Gender> UpdateGender(Gender gender);
        Task<Gender> CreateGender(Gender gender);
        Task<Gender?> DeleteGender(int id);

    }

    public class GenderRepository(ApplicationDbContext db) : IGenderRepository
    {
        public async Task<Gender?> GetGender(int id)
        {
            return await db.Gender.FindAsync(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await db.Gender.ToListAsync();
        }

        public async Task<Gender> CreateGender(Gender gender)
        {
            db.Gender.Add(gender);
            await db.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender> UpdateGender(Gender gender)
        {
            db.Entry(gender).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender?> DeleteGender(int id)
        {
            Gender? gender = await db.Gender.FindAsync(id);
            if (gender == null) return gender;
            gender.IsActive = false;
            db.Entry(gender).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return gender;
        }

    }

}

