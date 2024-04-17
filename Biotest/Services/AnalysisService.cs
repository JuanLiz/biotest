using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IAnalysisService
    {
        Task<IEnumerable<Analysis>> GetAnalyses();
        Task<Analysis?> GetAnalysis(int id);
        Task<Analysis> CreateAnalysis(
            int AnalysisTypeID,
            int GeneticTestID,
            DateTime Date,
            string Method,
            string Results
            );
        Task<Analysis> UpdateAnalysis(
            int AnalysisID,
            int? AnalysisTypeID,
            int? GeneticTestID,
            DateTime? Date,
            string? Method,
            string? Results
            );
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

        public async Task<Analysis> CreateAnalysis(
            int AnalysisTypeID,
            int GeneticTestID,
            DateTime Date,
            string Method,
            string Results
        )
        {
            return await analysisRepository.CreateAnalysis(new Analysis
            {
                AnalysisTypeID = AnalysisTypeID,
                GeneticTestID = GeneticTestID,
                Date = Date,
                Method = Method,
                Results = Results
            });
        }

        public async Task<Analysis> UpdateAnalysis(
            int AnalysisID,
            int? AnalysisTypeID,
            int? GeneticTestID,
            DateTime? Date,
            string? Method,
            string? Results
        )
        {
            Analysis? analysis = await analysisRepository.GetAnalysis(AnalysisID);
            if (analysis == null) throw new Exception("Analysis not found");

            // Check nullability. Replace only filled fields
            analysis.AnalysisTypeID = AnalysisTypeID ?? analysis.AnalysisTypeID;
            analysis.GeneticTestID = GeneticTestID ?? analysis.GeneticTestID;
            analysis.Date = Date ?? analysis.Date;
            analysis.Method = Method ?? analysis.Method;
            analysis.Results = Results ?? analysis.Results;
            return await analysisRepository.UpdateAnalysis(analysis);
        }

        public async Task<Analysis?> DeleteAnalysis(int id)
        {
            return await analysisRepository.DeleteAnalysis(id);
        }
    }
}
