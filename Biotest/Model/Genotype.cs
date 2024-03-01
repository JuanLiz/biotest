using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class Genotype
    {
        [Key]
        public required int GenotypeID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
