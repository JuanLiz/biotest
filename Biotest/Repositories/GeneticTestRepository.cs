using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticTestRepository
    {
        Task<IEnumerable<GeneticTest>> GetGeneticTest();
        Task<GeneticTest?> GetGeneticTest(int id);
        Task<GeneticTest> PutGeneticTest(int id, GeneticTest geneticTest);
        Task<GeneticTest> PostGeneticTest(GeneticTest geneticTest);
        Task<GeneticTest> DeleteGeneticTest(int id);
    }

    public class GeneticTestRepository : IGeneticTestRepository
    {
        private readonly ApplicationDbContext _db;

        public GeneticTestRepository(ApplicationDbContext db);
        {
            _db = db;
        }

        public async Task<GeneticTest?> GetGeneticTest(int id)
        {
            return await _db.GeneticTest.ToListAsync();
        }

        public async Task<IEnumerable<GeneticTest>> GetGeneticTest()
        {
            return await _db.GeneticTest.ToListAsync();
        }

        public async Taask<GeneticTest> PostGeneticTest(GeneticTest geneticTest)
        {
            _db.GeneticTest.Add(GeneticTest):
            await _db.SaveChangesAsync();
            return GeneticTest;
        }

        public async Task<GeneticTest> PutGeneticTest(int id, GeneticTest geneticTest)
        {
            _db.Entry(GeneticTest).State = EntityState.Modified;
            await _db.SaveChangesAsync(),
            return GeneticTest;
        }


        public Task<GeneticTest> DeleteGeneticTest(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}   