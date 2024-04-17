using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace Biotest.Model
{
    public class GeneticVariant
    {
        [Key]
        public int GeneticVariantID { get; set; }
        [ForeignKey(nameof(GeneticVariantType))]
        public required int GeneticVariantTypeID { get; set; }
        [ForeignKey(nameof(Analysis))]
        public required int AnalysisID { get; set; }
        [ForeignKey(nameof(Genotype))]
        public required int GenotypeID { get; set; }
        [MaxLength(30)]
        public required string Location { get; set; }
        [ForeignKey(nameof(PredictedEffect))]
        public required int PredictedEffectID { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        public virtual GeneticVariantType? GeneticVariantType { get; set; }
        public virtual Analysis? Analysis { get; set; }
        public virtual Genotype? Genotype { get; set; }
        public virtual PredictedEffect? PredictedEffect { get; set; }

    }
}
