using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticTestTypeRepository
    {
        Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes();
        Task<GeneticTestType?> GetGeneticTestType(int id);
        Task<GeneticTestType> PutGeneticTestType(int id, GeneticTestType geneticTestType);
        Task<GeneticTestType> PostGeneticTestType(GeneticTestType geneticTestType);
        Task<GeneticTestType?> DeleteGeneticTestType(int id);
    }

    public class GeneticTestTypeRepository : IGeneticTestTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public GeneticTestTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GeneticTestType?> GetGeneticTestType(int id)
        {
            return await _db.GeneticTestType.FindAsync(id);
        }

        public async Task<IEnumerable<GeneticTestType>> GetGeneticTestTypes()
        {
            return await _db.GeneticTestType.ToListAsync();
        }

        public async Task<GeneticTestType> PostGeneticTestType(GeneticTestType geneticTestType)
        {
            _db.GeneticTestType.Add(geneticTestType);
            await _db.SaveChangesAsync();
            return geneticTestType;
        }

        public async Task<GeneticTestType> PutGeneticTestType(int id, GeneticTestType geneticTestType)
        {
            _db.Entry(geneticTestType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return geneticTestType;
        }

        public Task<GeneticTestType?> DeleteGeneticTestType(int id)
        {
            throw new NotImplementedException();
        }

    }
}