using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IPredictedEffectRepository
    {
        Task<IEnumerable<PredictedEffect>> GetPredictedEffects();
        Task<PredictedEffect?> GetPredictedEffect(int id);
        Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect);
        Task<PredictedEffect> UpdatePredictedEffect(PredictedEffect predictedEffect);
        Task<PredictedEffect?> DeletePredictedEffect(int id);
    }

    public class PredictedEffectRepository(ApplicationDbContext db) : IPredictedEffectRepository
    {
        public async Task<PredictedEffect?> GetPredictedEffect(int id)
        {
            return await db.PredictedEffect.FindAsync(id);
        }

        public async Task<IEnumerable<PredictedEffect>> GetPredictedEffects()
        {
            return await db.PredictedEffect.ToListAsync();
        }

        public async Task<PredictedEffect> CreatePredictedEffect(PredictedEffect predictedEffect)
        {
            db.PredictedEffect.Add(predictedEffect);
            await db.SaveChangesAsync();
            return predictedEffect;
        }

        public async Task<PredictedEffect> UpdatePredictedEffect(PredictedEffect predictedEffect)
        {
            db.Entry(predictedEffect).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return predictedEffect;
        }

        public async Task<PredictedEffect?> DeletePredictedEffect(int id)
        {
            PredictedEffect? predictedEffect = await db.PredictedEffect.FindAsync(id);
            if (predictedEffect == null) return predictedEffect;
            predictedEffect.IsActive = false;
            db.Entry(predictedEffect).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return predictedEffect;
        }

    }

}