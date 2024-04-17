using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticVariantTypeRepository
    {
        Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes();
        Task<GeneticVariantType?> GetGeneticVariantType(int id);
        Task<GeneticVariantType> UpdateGeneticVariantType(GeneticVariantType geneticVariantType);
        Task<GeneticVariantType> CreateGeneticVariantType(GeneticVariantType geneticVariantType);
        Task<GeneticVariantType?> DeleteGeneticVariantType(int id);

    }

    public class GeneticVariantTypeRepository(ApplicationDbContext db) : IGeneticVariantTypeRepository
    {
        public async Task<GeneticVariantType?> GetGeneticVariantType(int id)
        {
            return await db.GeneticVariantType.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes()
        {
            return await db.GeneticVariantType.ToListAsync();
        }

        public async Task<GeneticVariantType> CreateGeneticVariantType(GeneticVariantType geneticVariantType)
        {
            db.GeneticVariantType.Add(geneticVariantType);
            await db.SaveChangesAsync();
            return geneticVariantType;
        }

        public async Task<GeneticVariantType> UpdateGeneticVariantType(GeneticVariantType geneticVariantType)
        {
            db.Entry(geneticVariantType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticVariantType;
        }

        public async Task<GeneticVariantType?> DeleteGeneticVariantType(int id)
        {
            GeneticVariantType? geneticVariantType = await db.GeneticVariantType.FindAsync(id);
            if (geneticVariantType == null) return geneticVariantType;
            geneticVariantType.IsActive = false;
            db.Entry(geneticVariantType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticVariantType;
        }
        
    }
    
}