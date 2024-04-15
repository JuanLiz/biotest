using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class SampleType
    {
        [Key]
        public int SampleTypeID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
