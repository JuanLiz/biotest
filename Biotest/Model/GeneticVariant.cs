using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Biotest.Model
{
    public class GeneticVariant
    {
        [Key]
        public int GeneticVariantID { get; set; }
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
        public virtual GeneticVariantType GeneticVariantType { get; set; }
        [ForeignKey("AnalysisID")]
        public virtual Analysis Analysis { get; set; }
        [ForeignKey("GenotypeID")]
        public virtual Genotype Genotype { get; set; }
        [ForeignKey("PredictedEffectID")]
        public virtual PredictedEffect PredictedEffect { get; set; }

    }
}
