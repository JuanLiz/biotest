using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{
    public interface IAnalysisTypeService
    {
        Task<IEnumerable<AnalysisType>> GetAnalysisTypes();
        Task<AnalysisType?> GetAnalysisType(int id);
        Task<AnalysisType> PostAnalysisType(AnalysisType analysisType);

        Task<AnalysisType?> PutAnalysisType(
            int id,
            string name);

        Task<AnalysisType?> DeleteAnalysisType(int id);


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

            public async Task<AnalysisType> PostAnalysisType(AnalysisType analysisType)
            {
                return await analysisTypeRepository.PostAnalysisType(analysisType);
            }

            public async Task<AnalysisType> PutAnalysisType(
                int id,
                string name
            )
            {
                AnalysisType? newAnalysisType = await analysisTypeRepository.GetAnalysisType(id);
                if (newAnalysisType == null)
                {
                    throw new Exception("AnalysisType not found");
                }
                else
                {
                    newAnalysisType.Name = name;
                    return await analysisTypeRepository.PutAnalysisType(id, newAnalysisType);
                }
            }

            public async Task<AnalysisType?> DeleteAnalysisType(int id)
            {
                return await analysisTypeRepository.DeleteAnalysisType(id);
            }
        }
    }
}
