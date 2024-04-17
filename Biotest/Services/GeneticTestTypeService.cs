using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGeneticTestTypeService
    {
        Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes();
        Task<GeneticTestType?> GetGeneticTestType(int id);
        Task<GeneticTestType> CreateGeneticTestType(string Name);
        Task<GeneticTestType> UpdateGeneticTestType(int GeneticTestTypeID, string? Name);
        Task<GeneticTestType?> DeleteGeneticTestType(int id);

    }

    public class GeneticTestTypeService(IGeneticTestTypeRepository geneticTestTypeRepository) : IGeneticTestTypeService
    {
        public async Task<GeneticTestType?> GetGeneticTestType(int id)
        {
            return await geneticTestTypeRepository.GetGeneticTestType(id);
        }

        public async Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes()
        {
            return await geneticTestTypeRepository.GetGeneticTestTypes();
        }

        public async Task<GeneticTestType> CreateGeneticTestType(string Name)
        {
            return await geneticTestTypeRepository.CreateGeneticTestType(new GeneticTestType { Name = Name });
        }

        public async Task<GeneticTestType> UpdateGeneticTestType(int GeneticTestTypeID, string? Name)
        {
            GeneticTestType? geneticTestType = await geneticTestTypeRepository.GetGeneticTestType(GeneticTestTypeID);
            if (geneticTestType == null) throw new Exception("GeneticTestType not found");
            geneticTestType.Name = Name ?? geneticTestType.Name;
            return await geneticTestTypeRepository.UpdateGeneticTestType(geneticTestType);
        }

        public async Task<GeneticTestType?> DeleteGeneticTestType(int id)
        {
            return await geneticTestTypeRepository.DeleteGeneticTestType(id);
        }
    }
}
