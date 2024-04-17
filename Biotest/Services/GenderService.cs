using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetGenders();
        Task<Gender?> GetGender(int id);
        Task<Gender> CreateGender(string Name);
        Task<Gender> UpdateGender(int GenderID, string? Name);
        Task<Gender?> DeleteGender(int id);

    }

    public class GenderService(IGenderRepository genderRepository) : IGenderService
    {
        public async Task<Gender?> GetGender(int id)
        {
            return await genderRepository.GetGender(id);
        }

        public async Task<IEnumerable<Gender>> GetGenders()
        {
            return await genderRepository.GetGenders();
        }

        public async Task<Gender> CreateGender(string Name)
        {
            return await genderRepository.CreateGender(new Gender { Name = Name });
        }

        public async Task<Gender> UpdateGender(int GenderID, string? Name)
        {
            Gender? gender = await genderRepository.GetGender(GenderID);
            if (gender == null) throw new Exception("Gender not found");
            gender.Name = Name ?? gender.Name;
            return await genderRepository.UpdateGender(gender);
        }

        public async Task<Gender?> DeleteGender(int id)
        {
            return await genderRepository.DeleteGender(id);
        }

    }
}
