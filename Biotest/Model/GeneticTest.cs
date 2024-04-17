using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class GeneticTest
    {
        [Key]
        public int GeneticTestID { get; set; }
        [ForeignKey(nameof(GeneticTestType))]
        public required int GeneticTestTypeID { get; set; }
        [ForeignKey(nameof(Sample))]
        public int? SampleID { get; set; }
        [ForeignKey(nameof(Employee))]
        public required int EmployeeID { get; set; }
        public required DateTime Date { get; set; }
        [MaxLength(300)]
        public required string Results { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;


        public virtual GeneticTestType? GeneticTestType { get; set; }
        public virtual Sample? Sample { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
