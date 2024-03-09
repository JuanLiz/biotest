using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IPredictEdeffectRepository
    {
        IEnumerable<PredictEdeffect> GetPredictEdeffects();
        PredictEdeffect GetPredictEdeffect(int id);
        PredictEdeffect PutPredictEdeffect(int id, PredictEdeffect predictEdeffect);
        PredictEdeffect PostPredictEdeffect(PredictEdeffect predictEdeffect);
        PredictEdeffect DeletePredictEdeffect(int id);
    }

    public class PredictEdeffectRepository : IPredictEdeffectRepository
    {
        public PredictEdeffect DeletePredictEdeffect(int id)
        {
            throw new NotImplementedException();
        }

        public PredictEdeffect GetPredictEdeffect(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PredictEdeffect> GetPredictEdeffects()
        {
            throw new NotImplementedException();
        }

        public PredictEdeffect PostPredictEdeffect(PredictEdeffect predictEdeffect)
        {
            throw new NotImplementedException();
        }

        public PredictEdeffect PutPredictEdeffect(int id, PredictEdeffect predictEdeffect)
        {
            throw new NotImplementedException();
        }
        
    }
    
}   