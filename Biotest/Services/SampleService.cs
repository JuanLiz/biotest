using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleService
    {
        Task<IEnumerable<Sample>> GetSamples();
        Task<Sample?> GetSample(int id);

        Task<Sample> CreateSample(
            int PatientID,
            DateTime Date,
            int SampleTypeID,
            int SampleSourceID);
        Task<Sample> UpdateSample(
            int SampleID,
            int? PatientID,
            DateTime? Date,
            int? SampleTypeID,
            int? SampleSourceID);

        Task<Sample?> DeleteSample(int id);

    }

    public class SampleService(ISampleRepository sampleRepository) : ISampleService
    {
        public async Task<Sample?> GetSample(int id)
        {
            return await sampleRepository.GetSample(id);
        }

        public async Task<IEnumerable<Sample>> GetSamples()
        {
            return await sampleRepository.GetSamples();
        }

        public async Task<Sample> CreateSample(
            int PatientID,
            DateTime Date,
            int SampleTypeID,
            int SampleSourceID
        )
        {
            return await sampleRepository.CreateSample(new Sample
            {
                PatientID = PatientID,
                Date = Date,
                SampleTypeID = SampleTypeID,
                SampleSourceID = SampleSourceID
            });
        }

        public async Task<Sample> UpdateSample(
            int SampleID,
            int? PatientID,
            DateTime? Date,
            int? SampleTypeID,
            int? SampleSourceID
        )
        {
            Sample? sample = await sampleRepository.GetSample(SampleID);
            if (sample == null) throw new Exception("Sample not found");
            sample.PatientID = PatientID ?? sample.PatientID;
            sample.Date = Date ?? sample.Date;
            sample.SampleTypeID = SampleTypeID ?? sample.SampleTypeID;
            sample.SampleSourceID = SampleSourceID ?? sample.SampleSourceID;
            return await sampleRepository.UpdateSample(sample);
        }

        public async Task<Sample?> DeleteSample(int id)
        {
            return await sampleRepository.DeleteSample(id);
        }
    }
}
