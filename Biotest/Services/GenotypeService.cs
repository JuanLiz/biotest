using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGenotypeService
    {
        Task<IEnumerable<Genotype>> GetGenotypes();
        Task<Genotype?> GetGenotype(int id);
        Task<Genotype> CreateGenotype(string Name);
        Task<Genotype> UpdateGenotype(int GenotypeID, string? Name);
        Task<Genotype?> DeleteGenotype(int id);
    }

    public class GenotypeService(IGenotypeRepository genotypeRepository) : IGenotypeService
    {
        public async Task<Genotype?> GetGenotype(int id)
        {
            return await genotypeRepository.GetGenotype(id);
        }

        public async Task<IEnumerable<Genotype>> GetGenotypes()
        {
            return await genotypeRepository.GetGenotypes();
        }

        public async Task<Genotype> CreateGenotype(string Name)
        {
            return await genotypeRepository.CreateGenotype(new Genotype { Name = Name });
        }

        public async Task<Genotype> UpdateGenotype(int GenotypeID, string? Name)
        {
            Genotype? genotype = await genotypeRepository.GetGenotype(GenotypeID);
            if (genotype == null) throw new Exception("Genotype not found");
            genotype.Name = Name ?? genotype.Name;
            return await genotypeRepository.UpdateGenotype(genotype);
        }

        public async Task<Genotype?> DeleteGenotype(int id)
        {
            return await genotypeRepository.DeleteGenotype(id);
        }
    }
}
