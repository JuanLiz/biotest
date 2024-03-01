using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class GeneticTest
    {
        [Key]
        public required int GeneticTestID { get; set; }
        [Required]
        public required int GeneticTestTypeID { get; set; }
        //TODO: Solve cascade error
        public int? SampleID { get; set; }
        [Required]
        public required int EmployeeID { get; set; }
        [Required]
        public required DateTime Date { get; set; }
        [Required]
        public required string Result { get; set; }

        [ForeignKey("GeneticTestTypeID")]
        public required GeneticTestType GeneticTestType { get; set; }
        [ForeignKey("SampleID")]
        public required Sample Sample { get; set; }
        [ForeignKey("EmployeeID")]
        public required Employee Employee { get; set; }
    }
}
