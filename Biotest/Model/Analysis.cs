using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Analysis
    {
        [Key]
        public int AnalysisID { get; set; }
        [Required]
        public required int AnalysisTypeID { get; set; }
        [Required]
        public required int GeneticTestID { get; set; }
        [Required]
        public required DateTime Date { get; set; }
        [Required]
        public required string Method { get; set; }
        [Required]
        public required string Results { get; set; }
        
        [ForeignKey("AnalysisTypeID")]
        public virtual AnalysisType AnalysisType { get; set; }
        [ForeignKey("GeneticTestID")]
        public virtual GeneticTest GeneticTest { get; set; }
    }
}
