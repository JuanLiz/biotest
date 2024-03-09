using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGeneticVariantRepository
    {
        IEnumerable<GeneticVariant> GetGeneticVariant();
        GeneticVariant GetGeneticVariant(int id);
        GeneticVariant PutGeneticVariant(int id, GeneticVariant geneticVariant);
        GeneticVariant PostGeneticVariant(GeneticVariant geneticVariant);
        GeneticVariant DeleteGeneticVariant(int id);
    }

    public class GeneticVariantRepository : IGeneticVariantRepository
    {
        public GeneticVariant DeleteGeneticVariant(int id)
        {
            throw new NotImplementedException();
        }

        public GeneticVariant GetGeneticVariant(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeneticVariant> GetGeneticVariant()
        {
            throw new NotImplementedException();
        }

        public GeneticVariant PostGeneticVariant(GeneticVariant geneticVariant)
        {
            throw new NotImplementedException();
        }

        public GeneticVariant PutGeneticVariant(int id, GeneticVariant geneticVariant)
        {
            throw new NotImplementedException();
        }
        
    }
    
}