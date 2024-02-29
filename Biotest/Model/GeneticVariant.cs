namespace Biotest.Model
{
    public class GeneticVariant
    {
        public required int GeneticVariantID { get; set; }
        public required int GeneticVariantTypeID { get; set; }
        public required int AnalysisID { get; set; }
        public required int GenotypeID { get; set; }
        public required string Location { get; set; }
        public required int PredictedEffectID { get; set; }

        public required GeneticVariantType GeneticVariantType { get; set; }
        public required AnalysisType AnalysisType { get; set; }
        public required Genotype Genotype { get; set; }
        public required PredictedEffect PredictedEffect { get; set; }

    }
}
