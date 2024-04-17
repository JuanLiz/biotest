using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleSourceService
    {
        Task<IEnumerable<SampleSource>> GetSampleSources();
        Task<SampleSource?> GetSampleSource(int id);
        Task<SampleSource> CreateSampleSource(string Name);
        Task<SampleSource> UpdateSampleSource(int SampleSourceID, string? Name);
        Task<SampleSource?> DeleteSampleSource(int id);

    }

    public class SampleSourceService(ISampleSourceRepository sampleSourceRepository) : ISampleSourceService
    {
        public async Task<SampleSource?> GetSampleSource(int id)
        {
            return await sampleSourceRepository.GetSampleSource(id);
        }

        public async Task<IEnumerable<SampleSource>> GetSampleSources()
        {
            return await sampleSourceRepository.GetSampleSources();
        }

        public async Task<SampleSource> CreateSampleSource(string Name)
        {
            return await sampleSourceRepository.CreateSampleSource(new SampleSource { Name = Name });
        }

        public async Task<SampleSource> UpdateSampleSource(int SampleSourceID, string? Name)
        {
            SampleSource? sampleSource = await sampleSourceRepository.GetSampleSource(SampleSourceID);
            if (sampleSource == null) throw new Exception("SampleSource not found");
            sampleSource.Name = Name ?? sampleSource.Name;
            return await sampleSourceRepository.UpdateSampleSource(sampleSource);
        }

        public async Task<SampleSource?> DeleteSampleSource(int id)
        {
            return await sampleSourceRepository.DeleteSampleSource(id);
        }
    }
}
