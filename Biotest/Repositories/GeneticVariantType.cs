using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGeneticVariantTypeRepository
    {
        IEnumerable<GeneticVariantType> GetGeneticVariantType();
        GeneticVariantType GetGeneticVariantType(int id);
        GeneticVariantType PutGeneticVariantType(int id, GeneticVariantType geneticVariantType);
        GeneticVariantType PostGeneticVariantType(GeneticVariantType geneticVariantType);
        GeneticVariantType DeleteGeneticVariantType(int id);
    }

    public class GeneticVariantTypeRepository : IGeneticVariantTypeRepository
    {
        public GeneticVariantType DeleteGeneticVariantType(int id)
        {
            throw new NotImplementedException();
        }

        public GeneticVariantType GetGeneticVariantType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeneticVariantType> GetGeneticVariantType()
        {
            throw new NotImplementedException();
        }

        public GeneticVariantType PostGeneticVariantType(GeneticVariantType geneticVariantType)
        {
            throw new NotImplementedException();
        }

        public GeneticVariantType PutGeneticVariantType(int id, GeneticVariantType geneticVariantType)
        {
            throw new NotImplementedException();
        }
        
    }
    
}