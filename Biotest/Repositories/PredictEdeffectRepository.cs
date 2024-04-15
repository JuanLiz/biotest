using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IPredictedEffectRepository
    {
        Task<IEnumerable<PredictedEffect>> GetPredictedEffects();
        Task<PredictedEffect> GetPredictedEffect(int id);
        Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect);
        Task<PredictedEffect> PutPredictedEffect(int id, PredictedEffect predictedEffect);
        Task<PredictedEffect?> DeletePredictedEffect(int id);
    }

    public class PredictedEffectRepository : IPredictedEffectRepository
    {
        private readonly ApplicationDbContext _db;

        public PredictedEffectRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PredictedEffect> GetPredictedEffect(int id)
        {
            return await _db.PredictedEffect.FindAsync(id);
        }

        public async Task<IEnumerable<PredictedEffect>> GetPredictedEffects()
        {
            return await _db.PredictedEffect.ToListAsync();
        }

        public async Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect)
        {
            _db.PredictedEffect.Add(predictedEffect);
            await _db.SaveChangesAsync();
            return predictedEffect;
        }

        public async Task<PredictedEffect> PutPredictedEffect(int id, PredictedEffect predictedEffect)
        {
            _db.Entry(predictedEffect).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return predictedEffect;
        }

        public Task<PredictedEffect?> DeletePredictedEffect(int id)
        {
            throw new NotImplementedException();
        }

    }

}