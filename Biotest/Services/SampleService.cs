using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface ISampleService
    {
        Task<IEnumerable<Sample>> GetSamples();
        Task<Sample?> GetSample(int id);
        Task<Sample> PostSample(Sample sample);
        Task<Sample> PutSample(
           int id,
           int PatientID,
           DateTime Date,
           int SampleTypeID,
           int SampleSourceID);
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

        public async Task<Sample> PostSample(Sample sample)
        {
            return await sampleRepository.PostSample(sample);
        }

        public async Task<Sample> PutSample(
            int id,
            int PatientID,
            DateTime Date,
            int SampleTypeID,
            int SampleSourceID
        )
        {
            Sample? newSample = await sampleRepository.GetSample(id);
            if (newSample == null)
            {
                throw new Exception("Sample not found");
            }
            else
            {
                newSample.PatientID = PatientID;
                newSample.Date = Date;
                newSample.SampleTypeID = SampleTypeID;
                newSample.SampleSourceID = SampleSourceID;
                return await sampleRepository.PutSample(id, newSample);
            }
        }

        public async Task<Sample?> DeleteSample(int id)
        {
            return await sampleRepository.DeleteSample(id);
        }
    }

}
