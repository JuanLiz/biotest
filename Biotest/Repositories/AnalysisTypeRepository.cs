using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IAnalysisTypeRepository
    {
        IEnumerable<AnalysisType> GetAnalysisTypes();
        AnalysisType GetAnalysisType(int id);
        AnalysisType PutAnalysisType(int id, AnalysisType analysisType);
        AnalysisType PostAnalysisType(AnalysisType analysisType);
        AnalysisType DeleteAnalysisType(int id);
    }

    public class AnalysisTypeRepository : IAnalysisTypeRepository
    {
        public AnalysisType DeleteAnalysisType(int id)
        {
            throw new NotImplementedException();
        }

        public AnalysisType GetAnalysisType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnalysisType> GetAnalysisTypes()
        {
            throw new NotImplementedException();
        }

        public AnalysisType PostAnalysisType(AnalysisType analysisType)
        {
            throw new NotImplementedException();
        }

        public AnalysisType PutAnalysisType(int id, AnalysisType analysisType)
        {
            throw new NotImplementedException();
        }
        
    }
    
}