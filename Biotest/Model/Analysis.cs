using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Analysis
    {
        [Key]
        public required int AnalysisID { get; set; }
        public required int AnalysisTypeID { get; set; }
        public required int GeneticTestID { get; set; }
        public required DateTime Date { get; set; }
        public required string Method { get; set; }
        public required string Results { get; set; }

        [ForeignKey("AnalysisTypeID")]
        public required AnalysisType AnalysisType { get; set; }
        [ForeignKey("GeneticTestID")]
        public required GeneticTest GeneticTest { get; set; }
    }
}
