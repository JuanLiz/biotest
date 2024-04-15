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
        Task<GeneticTest> CreateGeneticTest(GeneticTest geneticTest);
        Task<GeneticTest?> DeleteGeneticTest(int id);
    }

    public class GeneticTestRepository : IGeneticTestRepository
    {
        private readonly ApplicationDbContext _db;

        public GeneticTestRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<GeneticTest?> GetGeneticTest(int id)
        {
            return await _db.GeneticTest.FindAsync();
        }

        public async Task<IEnumerable<GeneticTest>> GetGeneticTest()
        {
            return await _db.GeneticTest.ToListAsync();
        }

        public async Task<GeneticTest> CreateGeneticTest(GeneticTest geneticTest)
        {
            _db.GeneticTest.Add(geneticTest);
            await _db.SaveChangesAsync();
            return geneticTest;
        }

        public async Task<GeneticTest> PutGeneticTest(int id, GeneticTest geneticTest)
        {
            _db.Entry(geneticTest).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return geneticTest;
        }


        public Task<GeneticTest?> DeleteGeneticTest(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}   