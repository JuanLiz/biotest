using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleSourceRepository
    {
        Task<IEnumerable<SampleSource>> GetSampleSources();
        Task<SampleSource?> GetSampleSource(int id);
        Task<SampleSource> CreateSampleSource(SampleSource sampleSource);
        Task<SampleSource> UpdateSampleSource(SampleSource sampleSource);
        Task<SampleSource?> DeleteSampleSource(int id);
    }

    public class SampleSourceRepository(ApplicationDbContext db) : ISampleSourceRepository
    {
        public async Task<SampleSource?> GetSampleSource(int id)
        {
            return await db.SampleSource.FindAsync(id);
        }

        public async Task<IEnumerable<SampleSource>> GetSampleSources()
        {
            return await db.SampleSource.ToListAsync();
        }

        public async Task<SampleSource> CreateSampleSource(SampleSource sampleSource)
        {
            db.SampleSource.Add(sampleSource);
            await db.SaveChangesAsync();
            return sampleSource;
        }

        public async Task<SampleSource> UpdateSampleSource(SampleSource sampleSource)
        {
            db.Entry(sampleSource).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sampleSource;
        }

        public async Task<SampleSource?> DeleteSampleSource(int id)
        {
            SampleSource? sampleSource = await db.SampleSource.FindAsync(id);
            if (sampleSource == null) return sampleSource;
            sampleSource.IsActive = false;
            db.Entry(sampleSource).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sampleSource;
        }

    }

}