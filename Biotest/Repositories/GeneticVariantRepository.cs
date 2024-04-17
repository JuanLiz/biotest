using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticVariantRepository
    {
        Task<IEnumerable<GeneticVariant>> GetGeneticVariants();
        Task<GeneticVariant?> GetGeneticVariant(int id);
        Task<GeneticVariant> UpdateGeneticVariant(GeneticVariant geneticVariant);
        Task<GeneticVariant> CreateGeneticVariant(GeneticVariant geneticVariant);
        Task<GeneticVariant?> DeleteGeneticVariant(int id);
    }

    public class GeneticVariantRepository(ApplicationDbContext db) : IGeneticVariantRepository
    {
        public async Task<GeneticVariant?> GetGeneticVariant(int id)
        {
            return await db.GeneticVariant.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticVariant>> GetGeneticVariants()
        {
            return await db.GeneticVariant.ToListAsync();
        }

        public async Task<GeneticVariant> CreateGeneticVariant(GeneticVariant geneticVariant)
        {
            db.GeneticVariant.Add(geneticVariant);
            await db.SaveChangesAsync();
            return geneticVariant;
        }

        public async Task<GeneticVariant> UpdateGeneticVariant(GeneticVariant geneticVariant)
        {
            db.Entry(geneticVariant).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticVariant;
        }

        public async Task<GeneticVariant?> DeleteGeneticVariant(int id)
        {
            GeneticVariant? geneticVariant = await db.GeneticVariant.FindAsync(id);
            if (geneticVariant == null) return geneticVariant;
            geneticVariant.IsActive = false;
            db.Entry(geneticVariant).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticVariant;
        }

    }

}