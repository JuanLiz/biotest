using Biotest.Model;

namespace Biotest.Repositories
{
    public interface ISampleSourceRepository
    {
        IEnumerable<SampleSource> GetSampleSources();
        SampleSource GetSampleSource(int id);
        SampleSource PutSampleSource(int id, SampleSource sampleSource);
        SampleSource PostSampleSource(SampleSource sampleSource);
        SampleSource DeleteSampleSource(int id);
    }

    public class SampleSourceRepository : ISampleSourceRepository
    {
        public SampleSource DeleteSampleSource(int id)
        {
            throw new NotImplementedException();
        }

        public SampleSource GetSampleSource(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SampleSource> GetSampleSources()
        {
            throw new NotImplementedException();
        }

        public SampleSource PostSampleSource(SampleSource sampleSource)
        {
            throw new NotImplementedException();
        }

        public SampleSource PutSampleSource(int id, SampleSource sampleSource)
        {
            throw new NotImplementedException();
        }
        
    }
    
}