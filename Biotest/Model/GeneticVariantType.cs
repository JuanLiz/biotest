using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class GeneticVariantType
    {
        [Key]
        public required int GeneticVariantTypeID { get; set; }
        public required string Name { get; set; }
    }
}
