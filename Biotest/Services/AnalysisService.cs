using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IAnalysisService
    {
        Task<IEnumerable<Analysis>> GetAnalyses();
        Task<Analysis?> GetAnalysis(int id);
        Task<Analysis> PostAnalysis(Analysis analysis);

        Task<Analysis> PutAnalysis(
                       int id,
                       int AnalysisTypeID,
                       int GeneticTestID,
                       DateTime Date,
                       string Method,
                       string Results);
        Task<Analysis?> DeleteAnalysis(int id);
    }

    public class AnalysisService(IAnalysisRepository analysisRepository) : IAnalysisService
    {
        public async Task<Analysis?> GetAnalysis(int id)
        {
            return await analysisRepository.GetAnalysis(id);
        }

        public async Task<IEnumerable<Analysis>> GetAnalyses()
        {
            return await analysisRepository.GetAnalyses();
        }

        public async Task<Analysis> PostAnalysis(Analysis analysis)
        {
            return await analysisRepository.PostAnalysis(analysis);
        }

        public async Task<Analysis> PutAnalysis(
            int id,
            int AnalysisTypeID,
            int GeneticTestID,
            DateTime Date,
            string Method,
            string Results
        )
        {
            Analysis? newAnalysis = await analysisRepository.GetAnalysis(id);
            if (newAnalysis == null)
            {
                throw new Exception("Analysis not found");
            }
            else
            {
                newAnalysis.AnalysisTypeID = AnalysisTypeID;
                newAnalysis.GeneticTestID = GeneticTestID;
                newAnalysis.Date = Date;
                newAnalysis.Method = Method;
                newAnalysis.Results = Results;
                return await analysisRepository.PutAnalysis(id, newAnalysis);
            }
        }
       
        public async Task<Analysis?> DeleteAnalysis(int id)
        {
            return await analysisRepository.DeleteAnalysis(id);
        }
    }
}
