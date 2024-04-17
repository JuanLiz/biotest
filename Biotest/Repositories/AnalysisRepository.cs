using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> GetAnalysis();
        Task<Analysis?> GetAnalysis(int id);
        Task<Analysis> UpdateAnalysis(Analysis analysis);
        Task<Analysis> CreateAnalysis(Analysis analysis);
        Task<Analysis?> DeleteAnalysis(int id);
    }

    public class AnalysisRepository(ApplicationDbContext db) : IAnalysisRepository
    {
        public async Task<Analysis?> GetAnalysis(int id)
        {
            return await db.Analysis.FindAsync(id);
        }

        public async Task<IEnumerable<Analysis>> GetAnalysis()
        {
            return await db.Analysis.ToListAsync();
        }

        public async Task<Analysis> CreateAnalysis(Analysis analysis)
        {
            db.Analysis.Add(analysis);
            await db.SaveChangesAsync();
            return analysis;
        }

        public async Task<Analysis> UpdateAnalysis(Analysis analysis)
        {
            db.Entry(analysis).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return analysis;
        }

        public async Task<Analysis?> DeleteAnalysis(int id)
        {
            Analysis? analysis = await db.Analysis.FindAsync(id);
            if (analysis == null) return analysis;
            analysis.IsActive = false;
            db.Entry(analysis).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return analysis;
        }
    }

}