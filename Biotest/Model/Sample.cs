using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Sample
    {
        [Key]
        public int SampleID { get; set; }
        [Required]
        public required int PatientID { get; set; }
        [Required]
        public required DateTime Date { get; set; }
        [Required]
        public required int SampleTypeID { get; set; }
        [Required]
        public required int SampleSourceID { get; set; }

        [ForeignKey("PatientID")]
        public virtual Patient? Patient { get; set; }
        [ForeignKey("SampleTypeID")]
        public virtual SampleType? SampleType { get; set; }
        [ForeignKey("SampleSourceID")]
        public virtual SampleSource? SampleSource { get; set; }

    }
}
