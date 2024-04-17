using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticTestTypeRepository
    {
        Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes();
        Task<GeneticTestType?> GetGeneticTestType(int id);
        Task<GeneticTestType> UpdateGeneticTestType(GeneticTestType geneticTestType);
        Task<GeneticTestType> CreateGeneticTestType(GeneticTestType geneticTestType);
        Task<GeneticTestType?> DeleteGeneticTestType(int id);
    }

    public class GeneticTestTypeRepository(ApplicationDbContext db) : IGeneticTestTypeRepository
    {
        public async Task<GeneticTestType?> GetGeneticTestType(int id)
        {
            return await db.GeneticTestType.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes()
        {
            return await db.GeneticTestType.ToListAsync();
        }

        public async Task<GeneticTestType> CreateGeneticTestType(GeneticTestType geneticTestType)
        {
            db.GeneticTestType.Add(geneticTestType);
            await db.SaveChangesAsync();
            return geneticTestType;
        }

        public async Task<GeneticTestType> UpdateGeneticTestType(GeneticTestType geneticTestType)
        {
            db.Entry(geneticTestType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticTestType;
        }

        public async Task<GeneticTestType?> DeleteGeneticTestType(int id)
        {
            GeneticTestType? geneticTestType = await db.GeneticTestType.FindAsync(id);
            if (geneticTestType == null) return geneticTestType;
            geneticTestType.IsActive = false;
            db.Entry(geneticTestType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticTestType;
        }

    }
}