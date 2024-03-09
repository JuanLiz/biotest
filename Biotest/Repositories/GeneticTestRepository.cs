using Biotest.Model;

namespace Biotest.Repositories
{
    public interface IGeneticTestRepository
    {
        IEnumerable<GeneticTest> GetGeneticTest();
        GeneticTest GetGeneticTest(int id);
        GeneticTest PutGeneticTest(int id, GeneticTest geneticTest);
        GeneticTest PostGeneticTest(GeneticTest geneticTest);
        GeneticTest DeleteGeneticTest(int id);
    }

    public class GeneticTestRepository : IGeneticTestRepository
    {
        public GeneticTest DeleteGeneticTest(int id)
        {
            throw new NotImplementedException();
        }

        public GeneticTest GetGeneticTest(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GeneticTest> GetGeneticTest()
        {
            throw new NotImplementedException();
        }

        public GeneticTest PostGeneticTest(GeneticTest geneticTest)
        {
            throw new NotImplementedException();
        }

        public GeneticTest PutGeneticTest(int id, GeneticTest geneticTest)
        {
            throw new NotImplementedException();
        }
        
    }
    
}   