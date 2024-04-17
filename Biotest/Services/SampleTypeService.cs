using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleTypeService
    {
        Task<IEnumerable<SampleType>> GetSampleTypes();
        Task<SampleType?> GetSampleType(int id);
        Task<SampleType> CreateSampleType(string Name);
        Task<SampleType> UpdateSampleType(int SampleTypeID, string? Name);
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

        public async Task<SampleType> CreateSampleType(string Name)
        {
            return await sampleTypeRepository.CreateSampleType(new SampleType { Name = Name });
        }

        public async Task<SampleType> UpdateSampleType(int SampleTypeID, string? Name)
        {
            SampleType? sampleType = await sampleTypeRepository.GetSampleType(SampleTypeID);
            if (sampleType == null) throw new Exception("SampleType not found");
            sampleType.Name = Name ?? sampleType.Name;
            return await sampleTypeRepository.UpdateSampleType(sampleType);
        }

        public async Task<SampleType?> DeleteSampleType(int id)
        {
            return await sampleTypeRepository.DeleteSampleType(id);
        }
    }
}
