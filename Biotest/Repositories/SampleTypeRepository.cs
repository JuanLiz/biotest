using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleTypeRepository
    {
        Task<IEnumerable<SampleType>> GetSampleTypes();
        Task<SampleType?> GetSampleType(int id);
        Task<SampleType> PostSampleType(SampleType sampleType);
        Task<SampleType> PutSampleType(int id, SampleType sampleType);
        Task<SampleType> DeleteSampleType(int id);


    }

    public class SampleTypeRepository : ISampleTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public SampleTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<SampleType?> GetSampleType(int id)
        {
            return await _db.SampleType.FindAsync(id);
        }

        public async Task<IEnumerable<SampleType>> GetSampleTypes()
        {
            return await _db.SampleType.ToListAsync();
        }

        public async Task<SampleType> PostSampleType(SampleType sampleType)
        {
            _db.SampleType.Add(sampleType);
            await _db.SaveChangesAsync();
            return sampleType;
        }

        public async Task<SampleType> PutSampleType(int id, SampleType sampleType)
        {
            _db.Entry(sampleType).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return sampleType;
        }

        public async Task<SampleType> DeleteSampleType(int id)
        {
            throw new NotImplementedException();
        }

    }

}