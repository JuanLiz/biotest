using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleSourceService
    {
        Task<IEnumerable<SampleSource>> GetSampleSources();
        Task<SampleSource?> GetSampleSource(int id);
        Task<SampleSource> PostSampleSource(SampleSource sampleSource);

        Task<SampleSource> PutSampleSource(
            int id,
            string name
        );

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

        public async Task<SampleSource> PostSampleSource(SampleSource sampleSource)
        {
            return await sampleSourceRepository.PostSampleSource(sampleSource);
        }

        public async Task<SampleSource> PutSampleSource(
            int id,
            string name
        )
        {
            SampleSource? newSampleSource = await sampleSourceRepository.GetSampleSource(id);
            if (newSampleSource == null)
            {
                throw new Exception("SampleSource not found");
            }
            else
            {
                newSampleSource.Name = name;
                return await sampleSourceRepository.PutSampleSource(id, newSampleSource);
            }
        }

        public async Task<SampleSource?> DeleteSampleSource(int id)
        {
            return await sampleSourceRepository.DeleteSampleSource(id);
        }
    }
}