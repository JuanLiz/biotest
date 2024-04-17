using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGeneticTestService
    {
        Task<IEnumerable<GeneticTest>> GetGeneticTests();
        Task<GeneticTest?> GetGeneticTest(int id);
        Task<GeneticTest> CreateGeneticTest(
            int GeneticTestTypeID,
            int SampleID,
            int EmployeeID,
            DateTime Date,
            string Results
            );
        Task<GeneticTest> UpdateGeneticTest(
            int GeneticTestID,
            int? GeneticTestTypeID,
            int? SampleID,
            int? EmployeeID,
            DateTime? Date,
            string? Results
            );

        Task<GeneticTest?> DeleteGeneticTest(int id);

    }

    public class GeneticTestService(IGeneticTestRepository geneticTestRepository) : IGeneticTestService
    {
        public async Task<GeneticTest?> GetGeneticTest(int id)
        {
            return await geneticTestRepository.GetGeneticTest(id);
        }

        public async Task<IEnumerable<GeneticTest>> GetGeneticTests()
        {
            return await geneticTestRepository.GetGeneticTests();
        }

        public async Task<GeneticTest> CreateGeneticTest(
            int GeneticTestTypeID,
            int SampleID,
            int EmployeeID,
            DateTime Date,
            string Results
        )
        {
            return await geneticTestRepository.CreateGeneticTest(new GeneticTest
            {
                GeneticTestTypeID = GeneticTestTypeID,
                SampleID = SampleID,
                EmployeeID = EmployeeID,
                Date = Date,
                Results = Results
            });
        }

        public async Task<GeneticTest> UpdateGeneticTest(
            int GeneticTestID,
            int? GeneticTestTypeID,
            int? SampleID,
            int? EmployeeID,
            DateTime? Date,
            string? Results
        )
        {
            GeneticTest? geneticTest = await geneticTestRepository.GetGeneticTest(GeneticTestID);
            if (geneticTest == null) throw new Exception("GeneticTest not found");
            geneticTest.GeneticTestTypeID = GeneticTestTypeID ?? geneticTest.GeneticTestTypeID;
            geneticTest.SampleID = SampleID ?? geneticTest.SampleID;
            geneticTest.EmployeeID = EmployeeID ?? geneticTest.EmployeeID;
            geneticTest.Date = Date ?? geneticTest.Date;
            geneticTest.Results = Results ?? geneticTest.Results;
            return await geneticTestRepository.UpdateGeneticTest(geneticTest);
        }

        public async Task<GeneticTest?> DeleteGeneticTest(int id)
        {
            return await geneticTestRepository.DeleteGeneticTest(id);
        }
    }
}
