using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleTypeService
    {
        Task<IEnumerable<SampleType>> GetSampleTypes();
        Task<SampleType?> GetSampleType(int id);
        Task<SampleType> CreateSampleType(SampleType sampleType);

        Task<SampleType> PutSampleType(
                       int id,
                       string name);

        Task<SampleType?> DeleteSampleType(int id);
    }

    public class SampleTypeService(ISampleTypeRepository sampleTypeRepository) : ISampleTypeService
    {
        public async Task<SampleType?> GetSampleType(int id)
        {
            return await sampleTypeRepository.GetSampleType(id);
        }

        public async Task<IEnumerable<SampleType>> GetSampleTypes()
        {
            return await sampleTypeRepository.GetSampleTypes();
        }

        public async Task<SampleType> CreateSampleType(SampleType sampleType)
        {
            return await sampleTypeRepository.CreateSampleType(sampleType);
        }

        public async Task<SampleType> PutSampleType(
            int id,
            string name
        )
        {
            SampleType? newSampleType = await sampleTypeRepository.GetSampleType(id);
            if (newSampleType == null)
            {
                throw new Exception("SampleType not found");
            }
            else
            {
                newSampleType.Name = name;
                return await sampleTypeRepository.PutSampleType(id, newSampleType);
            }
        }

        public async Task<SampleType?> DeleteSampleType(int id)
        {
            return await sampleTypeRepository.DeleteSampleType(id);
        }
    }
}
