using Biotest.Model;

namespace Biotest.Repositories
{
    public interface ISampleRepository
    {
        IEnumerable<Sample> GetSample();
        Sample GetSample(int id);
        Sample PutSample(int id, Sample sample);
        Sample PostSample(Sample sample);
        Sample DeleteSample(int id);
    }

    public class SampleRepository : ISampleRepository
    {
        public Sample DeleteSample(int id)
        {
            throw new NotImplementedException();
        }

        public Sample GetSample(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Sample> GetSample()
        {
            throw new NotImplementedException();
        }

        public Sample PostSample(Sample sample)
        {
            throw new NotImplementedException();
        }

        public Sample PutSample(int id, Sample sample)
        {
            throw new NotImplementedException();
        }
        
    }
    
}