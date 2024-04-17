using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleRepository
    {
        Task<IEnumerable<Sample>> GetSamples();
        Task<Sample?> GetSample(int id);
        Task<Sample> CreateSample(Sample sample);
        Task<Sample> UpdateSample(Sample sample);
        Task<Sample?> DeleteSample(int id);

    }

    public class SampleRepository(ApplicationDbContext db) : ISampleRepository
    {
        public async Task<Sample?> GetSample(int id)
        {
            return await db.Sample.FindAsync(id);
        }

        public async Task<IEnumerable<Sample>> GetSamples()
        {
            return await db.Sample.ToListAsync();
        }

        public async Task<Sample> CreateSample(Sample sample)
        {
            db.Sample.Add(sample);
            await db.SaveChangesAsync();
            return sample;
        }

        public async Task<Sample> UpdateSample(Sample sample)
        {
            db.Entry(sample).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sample;
        }

        public async Task<Sample?> DeleteSample(int id)
        {
            Sample? sample = await db.Sample.FindAsync(id);
            if (sample == null) return sample;
            sample.IsActive = false;
            db.Entry(sample).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sample;
        }
    }

}