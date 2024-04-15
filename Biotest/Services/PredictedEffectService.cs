using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IPredictedEffectService
    {
        Task<IEnumerable<PredictedEffect>> GetPredictedEffects();
        Task<PredictedEffect?> GetPredictedEffect(int id);
        Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect);
        Task<PredictedEffect> PutPredictedEffect(
            int id,
            string? Name
            );
        Task<PredictedEffect?> DeletePredictedEffect(int id);
    }


    public class PredictedEffectService
    {

        private readonly PredictedEffectRepository _predictedEffectRepository;

        public PredictedEffectService(PredictedEffectRepository predictedEffectRepository)
        {
            _predictedEffectRepository = predictedEffectRepository;
        }

        public async Task<PredictedEffect?> GetPredictedEffect(int id)
        {
            return await _predictedEffectRepository.GetPredictedEffect(id);
        }

        public async Task<IEnumerable<PredictedEffect>> GetPredictedEffects()
        {
            return await _predictedEffectRepository.GetPredictedEffects();
        }

        public async Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect)
        {
            return await _predictedEffectRepository.CreatePredictedEffect(predictedEffect);
        }

        public async Task<PredictedEffect> PutPredictedEffect(
            int id,
            string? Name
        )
        {
            PredictedEffect predictedEffect = await _predictedEffectRepository.GetPredictedEffect(id);
            if (predictedEffect == null)
            {
                throw new Exception("PredictedEffect not found");
            }
            else
            {
                predictedEffect.Name = Name ?? predictedEffect.Name;
                return await _predictedEffectRepository.PutPredictedEffect(id, predictedEffect);

            }
        }

        public async Task<PredictedEffect?> DeletePredictedEffect(int id)
        {
            return await _predictedEffectRepository.DeletePredictedEffect(id);
        }
    }
}
