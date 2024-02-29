using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Biotest.Model
{
    public class GeneticVariant
    {
        [Key]
        public required int GeneticVariantID { get; set; }
        public required int GeneticVariantTypeID { get; set; }
        public required int AnalysisID { get; set; }
        public required int GenotypeID { get; set; }
        public required string Location { get; set; }
        public required int PredictedEffectID { get; set; }

        [ForeignKey("GeneticVariantTypeID")]
        public required GeneticVariantType GeneticVariantType { get; set; }
        [ForeignKey("AnalysisID")]
        public required AnalysisType AnalysisType { get; set; }
        [ForeignKey("GenotypeID")]
        public required Genotype Genotype { get; set; }
        [ForeignKey("PredictedEffectID")]
        public required PredictedEffect PredictedEffect { get; set; }

    }
}
