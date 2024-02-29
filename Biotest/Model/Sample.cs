using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Sample
    {
        [Key]
        public required int SampleID { get; set; }
        public required int PatientID { get; set; }
        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public required int SampleTypeID { get; set; }
        public required int SampleSourceID { get; set; }

        [ForeignKey("PatientID")]
        public required Patient Patient { get; set; }
        [ForeignKey("SampleTypeID")]
        public required SampleType SampleType { get; set; }
        [ForeignKey("SampleSourceID")]
        public required SampleSource SampleSource { get; set; }

    }
}
