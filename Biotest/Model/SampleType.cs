using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class SampleType
    {
        [Key]
        public required int SampleTypeID { get; set; }
        public required string Name { get; set; }
    }
}
