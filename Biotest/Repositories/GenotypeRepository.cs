using Biotest.Context;
using Biotest.Model;
using Microsoft.EntityFrameworkCore;

namespace Biotest.Repositories
{
    public interface IGenotypeRepository
    {
        Task<IEnumerable<Genotype>> GetGenotype();
        Task<Genotype?> GetGenotype(int id);
        Task<Genotype> PutGenotype(int id, Genotype genotype);
        Task<Genotype> PostGenotype(Genotype genotype);
        Task<Genotype?> DeleteGenotype(int id);
    }

    public class GenotypeRepository : IGenotypeRepository
    {
        
        private readonly ApplicationDbContext _db;

        public GenotypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Genotype?> GetGenotype(int id)
        {
            return await _db.Genotype.FindAsync();
        }

        public async Task<IEnumerable<Genotype>> GetGenotype()
        {
            return await _db.Genotype.ToListAsync();
        }

        public async Task<Genotype> PostGenotype(Genotype genotype)
        {
            _db.Genotype.Add(genotype);
            await _db.SaveChangesAsync();
            return genotype;
        }

        public async Task<Genotype> PutGenotype(int id, Genotype genotype)
        {
            _db.Entry(genotype).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return genotype;
        }

        public Task<Genotype?> DeleteGenotype(int id)
        {
            throw new NotImplementedException();
        }
        
    }
    
}