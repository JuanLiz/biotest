using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class GeneticTest
    {
        [Key]
        public int GeneticTestID { get; set; }
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
        public virtual GeneticTestType GeneticTestType { get; set; }
        [ForeignKey("SampleID")]
        public virtual Sample Sample { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
    }
}
