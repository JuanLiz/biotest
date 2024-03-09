using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGenotypeRepository
    {
        IEnumerable<Genotype> GetGenotype();
        Genotype GetGenotype(int id);
        Genotype PutGenotype(int id, Genotype genotype);
        Genotype PostGenotype(Genotype genotype);
        Genotype DeleteGenotype(int id);
    }

    public class GenotypeRepository : IGenotypeRepository
    {
        public Genotype DeleteGenotype(int id)
        {
            throw new NotImplementedException();
        }

        public Genotype GetGenotype(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Genotype> GetGenotype()
        {
            throw new NotImplementedException();
        }

        public Genotype PostGenotype(Genotype genotype)
        {
            throw new NotImplementedException();
        }

        public Genotype PutGenotype(int id, Genotype genotype)
        {
            throw new NotImplementedException();
        }
        
    }
    
}