using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticVariantRepository
    {
        Task<IEnumerable<GeneticVariant>> GetGeneticVariants();
        Task<GeneticVariant?> GetGeneticVariant(int id);
        Task<GeneticVariant> PutGeneticVariant (int id, GeneticVariant geneticVariant);
        Task<GeneticVariant> CreateGeneticVariant(GeneticVariant geneticVariant);
        Task<GeneticVariant?> DeleteGeneticVariant(int id);
    }

    public class GeneticVariantRepository : IGeneticVariantRepository
    {
        private readonly ApplicationDbContext _db;

        public GeneticVariantRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GeneticVariant?> GetGeneticVariant(int id)
        {
            return await _db.GeneticVariant.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticVariant>> GetGeneticVariants()
        {
            return await _db.GeneticVariant.ToListAsync();
        }

        public async Task<GeneticVariant> CreateGeneticVariant(GeneticVariant geneticVariant)
        {
            _db.GeneticVariant.Add(geneticVariant);
            await _db.SaveChangesAsync();
            return geneticVariant;
        }  

        public async Task<GeneticVariant> PutGeneticVariant(int id, GeneticVariant geneticVariant)
        {
            _db.Entry(geneticVariant).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return geneticVariant;
        }

        public Task<GeneticVariant?> DeleteGeneticVariant(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}