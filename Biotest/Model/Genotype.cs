using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class Genotype
    {
        [Key]
        public int GenotypeID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
