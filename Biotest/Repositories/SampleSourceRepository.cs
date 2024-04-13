using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleSourceRepository
    {
        Task<IEnumerable<SampleSource>> GetSampleSources();
        Task<SampleSource> GetSampleSource(int id);
        Task<SampleSource> PostSampleSource(SampleSource sampleSource);
        Task<SampleSource> PutSampleSource(int id, SampleSource sampleSource);
        Task<SampleSource?> DeleteSampleSource(int id);
    }

    public class SampleSourceRepository : ISampleSourceRepository
    {
        private readonly ApplicationDbContext _db;

        public SampleSourceRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SampleSource> GetSampleSource(int id)
        {
            return await _db.SampleSource.FindAsync(id);
        }

        public async Task<IEnumerable<SampleSource>> GetSampleSources()
        {
            return await _db.SampleSource.ToListAsync();
        }

        public async Task<SampleSource> PostSampleSource(SampleSource sampleSource)
        {
            _db.SampleSource.Add(sampleSource);
            await _db.SaveChangesAsync();
            return sampleSource;
        }

        public async Task<SampleSource> PutSampleSource(int id, SampleSource sampleSource)
        {
            _db.Entry(sampleSource).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return sampleSource;
        }

        public Task<SampleSource?> DeleteSampleSource(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}