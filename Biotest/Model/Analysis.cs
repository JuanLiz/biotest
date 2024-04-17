using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class Analysis
    {
        [Key]
        public int AnalysisID { get; set; }

        [ForeignKey(nameof(AnalysisType))]
        public required int AnalysisTypeID { get; set; }
        [ForeignKey(nameof(GeneticTest))]
        public required int GeneticTestID { get; set; }
        public required DateTime Date { get; set; }
        [MaxLength(50)]
        public required string Method { get; set; }
        [MaxLength(500)]
        public required string Results { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual AnalysisType? AnalysisType { get; set; }
        public virtual GeneticTest? GeneticTest { get; set; }
    }
}
