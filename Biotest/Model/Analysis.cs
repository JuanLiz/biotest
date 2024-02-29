namespace Biotest.Model
{
    public class Analysis
    {
        public required int AnalysisID { get; set; }
        public required int AnalysisTypeID { get; set; }
        public required int GeneticTestID { get; set; }
        public required DateTime Date { get; set; }
        public required string Method { get; set; }
        public required string Results { get; set; }

        public required AnalysisType AnalysisType { get; set; }
        public required GeneticTest GeneticTest { get; set; }
    }
}
