using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticVariantTypeRepository
    {
        Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes();
        Task<GeneticVariantType?> GetGeneticVariantType(int id);
        Task<GeneticVariantType> PutGeneticVariantType(int id, GeneticVariantType geneticVariantType);
        Task<GeneticVariantType> PostGeneticVariantType(GeneticVariantType geneticVariantType);
        Task<GeneticVariantType> DeleteGeneticVariantType(int id);

    }

    public class GeneticVariantTypeRepository : IGeneticVariantTypeRepository
    {
       private readonly ApplicationDbContext _db;

        public GeneticVariantTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GeneticVariantType?> GetGeneticVariantType(int id)
        {
            return await _db.GeneticVariantType.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticVariantType>> GetGeneticVariantTypes()
        {
            return await _db.GeneticVariantType.ToListAsync();
        }

        public async Task<GeneticVariantType> PostGeneticVariantType(GeneticVariantType geneticVariantType)
        {
            _db.GeneticVariantType.Add(geneticVariantType);
            await _db.SaveChangesAsync();
            return geneticVariantType;
        }

        public async Task<GeneticVariantType> PutGeneticVariantType(int id, GeneticVariantType geneticVariantType)
        {
            _db.Entry(geneticVariantType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return geneticVariantType;
        }

        public Task<GeneticVariantType> DeleteGeneticVariantType(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}