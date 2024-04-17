using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenotypeRepository
    {
        Task<IEnumerable<Genotype>> GetGenotypes();
        Task<Genotype?> GetGenotype(int id);
        Task<Genotype> UpdateGenotype(Genotype genotype);
        Task<Genotype> CreateGenotype(Genotype genotype);
        Task<Genotype?> DeleteGenotype(int id);
    }

    public class GenotypeRepository(ApplicationDbContext db) : IGenotypeRepository
    {
        public async Task<Genotype?> GetGenotype(int id)
        {
            return await db.Genotype.FindAsync();
        }

        public async Task<IEnumerable<Genotype>> GetGenotypes()
        {
            return await db.Genotype.ToListAsync();
        }

        public async Task<Genotype> CreateGenotype(Genotype genotype)
        {
            db.Genotype.Add(genotype);
            await db.SaveChangesAsync();
            return genotype;
        }

        public async Task<Genotype> UpdateGenotype(Genotype genotype)
        {
            db.Entry(genotype).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return genotype;
        }

        public async Task<Genotype?> DeleteGenotype(int id)
        {
            Genotype? genotype = await db.Genotype.FindAsync(id);
            if (genotype == null) return genotype;
            genotype.IsActive = false;
            db.Entry(genotype).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return genotype;
        }
        
    }
    
}