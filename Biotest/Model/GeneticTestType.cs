using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class GeneticTestType
    {
        [Key]
        public required int GeneticTestTypeID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
