using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class Sample
    {
        [Key]
        public int SampleID { get; set; }
        [ForeignKey(nameof(Patient))]
        public required int PatientID { get; set; }
        public required DateTime Date { get; set; }
        [ForeignKey(nameof(SampleType))]
        public required int SampleTypeID { get; set; }
        [ForeignKey(nameof(SampleSource))]
        public required int SampleSourceID { get; set; }
        [JsonIgnore]
        public required bool IsActive { get; set; } = true;

        public virtual Patient? Patient { get; set; }
        
        public virtual SampleType? SampleType { get; set; }
        
        public virtual SampleSource? SampleSource { get; set; }

    }
}
