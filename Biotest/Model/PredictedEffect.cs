using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class PredictedEffect
    {
        [Key]
        public required int PredictedEffectID { get; set; }
        public required string Name { get; set; }
    }
}
