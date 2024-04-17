using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IAnalysisTypeRepository
    {
        Task<IEnumerable<AnalysisType>> GetAnalysisTypes();
        Task<AnalysisType?> GetAnalysisType(int id);
        Task<AnalysisType> UpdateAnalysisType(AnalysisType analysisType);
        Task<AnalysisType> CreateAnalysisType(AnalysisType analysisType);
        Task<AnalysisType?> DeleteAnalysisType(int id);
    }

    public class AnalysisTypeRepository(ApplicationDbContext db) : IAnalysisTypeRepository
    {
        public async Task<AnalysisType?> GetAnalysisType(int id)
        {
            return await db.AnalysisType.FindAsync(id);
        }

        public async Task<IEnumerable<AnalysisType>> GetAnalysisTypes()
        {
            return await db.AnalysisType.ToListAsync();
        }
        public async Task<AnalysisType> CreateAnalysisType(AnalysisType analysisType)
        {
            db.AnalysisType.Add(analysisType);
            await db.SaveChangesAsync();
            return analysisType;
        }
        public async Task<AnalysisType> UpdateAnalysisType(AnalysisType analysisType)
        {
            db.Entry(analysisType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return analysisType;
        }

        public async Task<AnalysisType?> DeleteAnalysisType(int id)
        {
            AnalysisType? analysisType = await db.AnalysisType.FindAsync(id);
            if (analysisType == null) return analysisType;
            analysisType.IsActive = false;
            db.Entry(analysisType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return analysisType;
        }
    }

}