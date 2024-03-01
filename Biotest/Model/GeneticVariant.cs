using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Biotest.Model
{
    public class GeneticVariant
    {
        [Key]
        public required int GeneticVariantID { get; set; }
        [Required]
        public required int GeneticVariantTypeID { get; set; }
        [Required]
        public required int AnalysisID { get; set; }
        [Required]
        public required int GenotypeID { get; set; }
        public required string Location { get; set; }
        [Required]
        public required int PredictedEffectID { get; set; }

        [ForeignKey("GeneticVariantTypeID")]
        public required GeneticVariantType GeneticVariantType { get; set; }
        [ForeignKey("AnalysisID")]
        public required Analysis Analysis { get; set; }
        [ForeignKey("GenotypeID")]
        public required Genotype Genotype { get; set; }
        [ForeignKey("PredictedEffectID")]
        public required PredictedEffect PredictedEffect { get; set; }

    }
}
