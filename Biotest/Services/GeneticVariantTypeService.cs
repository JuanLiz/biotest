using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGeneticVariantTypeService
    {
        Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes();
        Task<GeneticVariantType?> GetGeneticVariantType(int id);
        Task<GeneticVariantType> CreateGeneticVariantType(string Name);
        Task<GeneticVariantType> UpdateGeneticVariantType(int GeneticVariantTypeID, string? Name);
        Task<GeneticVariantType?> DeleteGeneticVariantType(int id);
    }

    public class GeneticVariantTypeService(IGeneticVariantTypeRepository geneticVariantTypeRepository)
        : IGeneticVariantTypeService
    {
        public async Task<GeneticVariantType?> GetGeneticVariantType(int id)
        {
            return await geneticVariantTypeRepository.GetGeneticVariantType(id);
        }

        public async Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes()
        {
            return await geneticVariantTypeRepository.GetGeneticVariantTypes();
        }

        public async Task<GeneticVariantType> CreateGeneticVariantType(string Name)
        {
            return await geneticVariantTypeRepository.CreateGeneticVariantType(new GeneticVariantType { Name = Name });
        }

        public async Task<GeneticVariantType> UpdateGeneticVariantType(int GeneticVariantTypeID, string? Name)
        {
            GeneticVariantType? geneticVariantType = await geneticVariantTypeRepository.GetGeneticVariantType(GeneticVariantTypeID);
            if (geneticVariantType == null) throw new Exception("GeneticVariantType not found");
            geneticVariantType.Name = Name ?? geneticVariantType.Name;
            return await geneticVariantTypeRepository.UpdateGeneticVariantType(geneticVariantType);
        }

        public async Task<GeneticVariantType?> DeleteGeneticVariantType(int id)
        {
            return await geneticVariantTypeRepository.DeleteGeneticVariantType(id);
        }
    }
}
