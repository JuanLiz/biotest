using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGeneticTestRepository
    {
        Task<IEnumerable<GeneticTest>> GetGeneticTests();
        Task<GeneticTest?> GetGeneticTest(int id);
        Task<GeneticTest> UpdateGeneticTest(GeneticTest geneticTest);
        Task<GeneticTest> CreateGeneticTest(GeneticTest geneticTest);
        Task<GeneticTest?> DeleteGeneticTest(int id);
    }

    public class GeneticTestRepository(ApplicationDbContext db) : IGeneticTestRepository
    {
        public async Task<GeneticTest?> GetGeneticTest(int id)
        {
            return await db.GeneticTest.FindAsync();
        }

        public async Task<IEnumerable<GeneticTest>> GetGeneticTests()
        {
            return await db.GeneticTest.ToListAsync();
        }

        public async Task<GeneticTest> CreateGeneticTest(GeneticTest geneticTest)
        {
            db.GeneticTest.Add(geneticTest);
            await db.SaveChangesAsync();
            return geneticTest;
        }

        public async Task<GeneticTest> UpdateGeneticTest(GeneticTest geneticTest)
        {
            db.Entry(geneticTest).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticTest;
        }


        public async Task<GeneticTest?> DeleteGeneticTest(int id)
        {
            GeneticTest? geneticTest = await db.GeneticTest.FindAsync(id);
            if (geneticTest == null) return geneticTest;
            geneticTest.IsActive = false;
            db.Entry(geneticTest).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return geneticTest;
        }

    }

}