using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IAnalysisTypeService
    {
        Task<IEnumerable<AnalysisType>> GetAnalysisTypes();
        Task<AnalysisType?> GetAnalysisType(int id);
        Task<AnalysisType> CreateAnalysisType(string Name);
        Task<AnalysisType> UpdateAnalysisType(int AnalysisTypeID, string? Name);
        Task<AnalysisType?> DeleteAnalysisType(int id);

    }

    public class AnalysisTypeService(IAnalysisTypeRepository analysisTypeRepository) : IAnalysisTypeService
    {
        public async Task<AnalysisType?> GetAnalysisType(int id)
        {
            return await analysisTypeRepository.GetAnalysisType(id);
        }

        public async Task<IEnumerable<AnalysisType>> GetAnalysisTypes()
        {
            return await analysisTypeRepository.GetAnalysisTypes();
        }

        public async Task<AnalysisType> CreateAnalysisType(string Name)
        {
            return await analysisTypeRepository.CreateAnalysisType(new AnalysisType { Name = Name });
        }

        public async Task<AnalysisType> UpdateAnalysisType(int AnalysisTypeID, string? Name)
        {
            AnalysisType? analysisType = await analysisTypeRepository.GetAnalysisType(AnalysisTypeID);
            if (analysisType == null) throw new Exception("AnalysisType not found");
            analysisType.Name = Name ?? analysisType.Name;
            return await analysisTypeRepository.UpdateAnalysisType(analysisType);
        }

        public async Task<AnalysisType?> DeleteAnalysisType(int id)
        {
            return await analysisTypeRepository.DeleteAnalysisType(id);
        }
    }
}
