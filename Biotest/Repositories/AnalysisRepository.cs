using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<Analysis>> GetAnalysis();
        Task<Analysis?> GetAnalysis(int id);
        Task<Analysis> PutAnalysis(int id, Analysis analysis);
        Task<Analysis> CreateAnalysis(Analysis analysis);
        Task<Analysis?> DeleteAnalysis(int id);
    }

    public class AnalysisRepository : IAnalysisRepository
    {

        private readonly ApplicationDbContext _db;
        public AnalysisRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Analysis?> GetAnalysis(int id)
        {
            return await _db.Analysis.FindAsync(id);
        }

        public async Task<IEnumerable<Analysis>> GetAnalysis()
        {
            return await _db.Analysis.ToListAsync();
        }

        public async Task<Analysis> CreateAnalysis(Analysis analysis)
        {
            _db.Analysis.Add(analysis);
            await _db.SaveChangesAsync();
            return analysis;
        }

        public async Task<Analysis> PutAnalysis(int id, Analysis analysis)
        {
            // Simplified function to update a patient
            _db.Entry(analysis).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return analysis;
        }

        public Task<Analysis?> DeleteAnalysis(int id)
        {
            // Change boolean state
            throw new NotImplementedException();
        }
    }
    
}