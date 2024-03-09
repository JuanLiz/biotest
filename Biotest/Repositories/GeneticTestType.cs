using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGeneticTestTypeRepository
    {
        IEnumerable<GeneticTestType> GetGeneticTestType();
        GeneticTestType GetGeneticTestType(int id);
        GeneticTestType PutGeneticTestType(int id, GeneticTestType geneticTestType);
        GeneticTestType PostGeneticTestType(GeneticTestType geneticTestType);
        GeneticTestType DeleteGeneticTestType(int id);
    }

    public class GeneticTestTypeRepository : IGeneticTestTypeRepository
    {
        public GeneticTestType DeleteGeneticTestType(int id)
        {
            throw new NotImplementedException();
        }

        public GeneticTestType GetGeneticTestType(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeneticTestType> GetGeneticTestType()
        {
            throw new NotImplementedException();
        }

        public GeneticTestType PostGeneticTestType(GeneticTestType geneticTestType)
        {
            throw new NotImplementedException();
        }

        public GeneticTestType PutGeneticTestType(int id, GeneticTestType geneticTestType)
        {
            throw new NotImplementedException();
        }
        
    }
    
}