using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IPredictedEffectService
    {
        Task<IEnumerable<PredictedEffect>> GetPredictedEffects();
        Task<PredictedEffect?> GetPredictedEffect(int id);
        Task<PredictedEffect> CreatePredictedEffect(string Name);
        Task<PredictedEffect> UpdatePredictedEffect(int PredictedEffectID, string? Name);
        Task<PredictedEffect?> DeletePredictedEffect(int id);
    }

    public class PredictedEffectService(IPredictedEffectRepository predictedEffectRepository) : IPredictedEffectService
    {
        public async Task<PredictedEffect?> GetPredictedEffect(int id)
        {
            return await predictedEffectRepository.GetPredictedEffect(id);
        }

        public async Task<IEnumerable<PredictedEffect>> GetPredictedEffects()
        {
            return await predictedEffectRepository.GetPredictedEffects();
        }

        public async Task<PredictedEffect> CreatePredictedEffect(string Name)
        {
            return await predictedEffectRepository.CreatePredictedEffect(new PredictedEffect { Name = Name });
        }

        public async Task<PredictedEffect> UpdatePredictedEffect(int PredictedEffectID, string? Name)
        {
            PredictedEffect? predictedEffect = await predictedEffectRepository.GetPredictedEffect(PredictedEffectID);
            if (predictedEffect == null) throw new Exception("PredictedEffect not found");
            predictedEffect.Name = Name ?? predictedEffect.Name;
            return await predictedEffectRepository.UpdatePredictedEffect(predictedEffect);
        }

        public async Task<PredictedEffect?> DeletePredictedEffect(int id)
        {
            return await predictedEffectRepository.DeletePredictedEffect(id);
        }
    }
}
