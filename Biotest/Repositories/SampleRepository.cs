using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleRepository
    {
        Task<IEnumerable<Sample>> GetSamples();
        Task<Sample> GetSample(int id);
        Task<Sample> PostSample(Sample sample);
        Task<Sample> PutSample(int id, Sample sample);
        Task<Sample?> DeleteSample(int id);

    }

    public class SampleRepository : ISampleRepository
    {
        private readonly ApplicationDbContext _db;

        public SampleRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Sample> GetSample(int id)
        {
            return await _db.Sample.FindAsync(id);
        }

        public async Task<IEnumerable<Sample>> GetSamples()
        {
            return await _db.Sample.ToListAsync();
        }

        public async Task<Sample> PostSample(Sample sample)
        {
            _db.Sample.Add(sample);
            await _db.SaveChangesAsync();
            return sample;
        }

        public async Task<Sample> PutSample(int id, Sample sample)
        {
            _db.Entry(sample).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return sample;
        }

        public Task<Sample?> DeleteSample(int id)
        {
            throw new NotImplementedException();
        }
    }
    
}