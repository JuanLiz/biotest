using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IAnalysisRepository
    {
        IEnumerable<Analysis> GetAnalysis();
        Analysis GetAnalysis(int id);
        Analysis PutAnalysis(int id, Analysis analysis);
        Analysis PostAnalysis(Analysis analysis);
        Analysis DeleteAnalysis(int id);
    }

    public class AnalysisRepository : IAnalysisRepository
    {
        public Analysis DeleteAnalysis(int id)
        {
            throw new NotImplementedException();
        }

        public Analysis GetAnalysis(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Analysis> GetAnalysis()
        {
            throw new NotImplementedException();
        }

        public Analysis PostAnalysis(Analysis analysis)
        {
            throw new NotImplementedException();
        }

        public Analysis PutAnalysis(int id, Analysis analysis)
        {
            throw new NotImplementedException();
        }
        
    }
    
}