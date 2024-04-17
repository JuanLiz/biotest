using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface ISampleTypeRepository
    {
        Task<IEnumerable<SampleType>> GetSampleTypes();
        Task<SampleType?> GetSampleType(int id);
        Task<SampleType> CreateSampleType(SampleType sampleType);
        Task<SampleType> UpdateSampleType(SampleType sampleType);
        Task<SampleType?> DeleteSampleType(int id);

    }

    public class SampleTypeRepository(ApplicationDbContext db) : ISampleTypeRepository
    {
        public async Task<SampleType?> GetSampleType(int id)
        {
            return await db.SampleType.FindAsync(id);
        }

        public async Task<IEnumerable<SampleType>> GetSampleTypes()
        {
            return await db.SampleType.ToListAsync();
        }

        public async Task<SampleType> CreateSampleType(SampleType sampleType)
        {
            db.SampleType.Add(sampleType);
            await db.SaveChangesAsync();
            return sampleType;
        }

        public async Task<SampleType> UpdateSampleType(SampleType sampleType)
        {
            db.Entry(sampleType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sampleType;
        }

        public async Task<SampleType?> DeleteSampleType(int id)
        {
            SampleType? sampleType = await db.SampleType.FindAsync(id);
            if (sampleType == null) return sampleType;
            sampleType.IsActive = false;
            db.Entry(sampleType).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return sampleType;
        }

    }

}