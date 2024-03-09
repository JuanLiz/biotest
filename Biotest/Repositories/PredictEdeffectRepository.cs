using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IPredictedEffectRepository
    {
        IEnumerable<PredictedEffect> GetPredictedEffect();
        PredictedEffect GetPredictedEffect(int id);
        PredictedEffect PutPredictedEffect(int id, PredictedEffect predictedEffect);
        PredictedEffect PostPredictedEffect(PredictedEffect predictedEffect);
        PredictedEffect DeletePredictedEffect(int id);
    }

    public class PredictedEffectRepository : IPredictedEffectRepository
    {
        public PredictedEffect DeletePredictedEffect(int id)
        {
            throw new NotImplementedException();
        }

        public PredictedEffect GetPredictedEffect(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PredictedEffect> GetPredictedEffect()
        {
            throw new NotImplementedException();
        }

        public PredictedEffect PostPredictedEffect(PredictedEffect predictedEffect)
        {
            throw new NotImplementedException();
        }

        public PredictedEffect PutPredictedEffect(int id, PredictedEffect predictedEffect)
        {
            throw new NotImplementedException();
        }
        
    }
    
}