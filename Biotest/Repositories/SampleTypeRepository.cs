using Biotest.Model;

namespace Biotest.Repositories
{
    public interface ISampleTypeRepository
    {
        IEnumerable<SampleType> GetSampleType();
        SampleType GetSampleType(int id);
        SampleType PutSampleType(int id, SampleType sampleType);
        SampleType PostSampleType(SampleType sampleType);
        SampleType DeleteSampleType(int id);
    }

    public class SampleTypeRepository : ISampleTypeRepository
    {
        public SampleType DeleteSampleType(int id)
        {
            throw new NotImplementedException();
        }

        public SampleType GetSampleType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleType> GetSampleType()
        {
            throw new NotImplementedException();
        }

        public SampleType PostSampleType(SampleType sampleType)
        {
            throw new NotImplementedException();
        }

        public SampleType PutSampleType(int id, SampleType sampleType)
        {
            throw new NotImplementedException();
        }
        
    }
    
}