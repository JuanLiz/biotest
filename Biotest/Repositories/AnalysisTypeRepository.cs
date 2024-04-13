using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IAnalysisTypeRepository
    {
        Task<IEnumerable<AnalysisType>> GetAnalysisTypes();
        Task<AnalysisType?> GetAnalysisType(int id);
        Task<AnalysisType> PutAnalysisType(int id, AnalysisType analysisType);
        Task<AnalysisType> PostAnalysisType(AnalysisType analysisType);
        Task<AnalysisType?> DeleteAnalysisType(int id);
    }

    public class AnalysisTypeRepository : IAnalysisTypeRepository
    {

        private readonly ApplicationDbContext _db;

        public AnalysisTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<AnalysisType?> GetAnalysisType(int id)
        {
            // Simplified function to get a patient by id
            return await _db.AnalysisType.FindAsync(id);
        }

        public async Task<IEnumerable<AnalysisType>> GetAnalysisTypes()
        {
            // Simplified function to get all patients
            return await _db.AnalysisType.ToListAsync();
        }
        public async Task<AnalysisType> PostAnalysisType(AnalysisType analysisType)
        {
            // Simplified function to add a patient
            _db.AnalysisType.Add(analysisType);
            await _db.SaveChangesAsync();
            return analysisType;
        }
        public async Task<AnalysisType> PutAnalysisType(int id, AnalysisType analysisType)
        {
            // Simplified function to update a patient
            _db.Entry(analysisType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return analysisType;
        }

        public Task<AnalysisType?> DeleteAnalysisType(int id)
        {
            throw new NotImplementedException();
        }
    }
    
}