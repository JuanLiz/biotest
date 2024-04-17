using Biotest.Model;
using Biotest.Repositories;

namespace Biotest.Services
{

    public interface IGeneticVariantService
    {
        Task<IEnumerable<GeneticVariant>> GetGeneticVariants();
        Task<GeneticVariant?> GetGeneticVariant(int id);

        Task<GeneticVariant> CreateGeneticVariant(
            int GeneticVariantTypeID,
            int AnalysisID,
            int GenotypeID,
            string Location,
            int PredictedEffectID);


        Task<GeneticVariant> UpdateGeneticVariant(
            int GeneticVariantID,
            int? GeneticVariantTypeID,
            int? AnalysisID,
            int? GenotypeID,
            string? Location,
            int? PredictedEffectID);

        Task<GeneticVariant?> DeleteGeneticVariant(int id);

    }

    public class GeneticVariantService(IGeneticVariantRepository geneticVariantRepository) : IGeneticVariantService
    {
        public async Task<GeneticVariant?> GetGeneticVariant(int id)
        {
            return await geneticVariantRepository.GetGeneticVariant(id);
        }

        public async Task<IEnumerable<GeneticVariant>> GetGeneticVariants()
        {
            return await geneticVariantRepository.GetGeneticVariants();
        }

        public async Task<GeneticVariant> CreateGeneticVariant(
            int GeneticVariantTypeID,
            int AnalysisID,
            int GenotypeID,
            string Location,
            int PredictedEffectID
        )
        {
            return await geneticVariantRepository.CreateGeneticVariant(new GeneticVariant
            {
                GeneticVariantTypeID = GeneticVariantTypeID,
                AnalysisID = AnalysisID,
                GenotypeID = GenotypeID,
                Location = Location,
                PredictedEffectID = PredictedEffectID
            });
        }

        public async Task<GeneticVariant> UpdateGeneticVariant(
            int GeneticVariantID,
            int? GeneticVariantTypeID,
            int? AnalysisID,
            int? GenotypeID,
            string? Location,
            int? PredictedEffectID
        )
        {
            GeneticVariant? geneticVariant = await geneticVariantRepository.GetGeneticVariant(GeneticVariantID);
            if (geneticVariant == null) throw new Exception("GeneticVariant not found");
            geneticVariant.GeneticVariantTypeID = GeneticVariantTypeID ?? geneticVariant.GeneticVariantTypeID;
            geneticVariant.AnalysisID = AnalysisID ?? geneticVariant.AnalysisID;
            geneticVariant.GenotypeID = GenotypeID ?? geneticVariant.GenotypeID;
            geneticVariant.Location = Location ?? geneticVariant.Location;
            geneticVariant.PredictedEffectID = PredictedEffectID ?? geneticVariant.PredictedEffectID;
            return await geneticVariantRepository.UpdateGeneticVariant(geneticVariant);
        }

        public async Task<GeneticVariant?> DeleteGeneticVariant(int id)
        {
            return await geneticVariantRepository.DeleteGeneticVariant(id);
        }
    }
}
