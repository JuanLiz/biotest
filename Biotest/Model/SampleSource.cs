using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class SampleSource
    {
        [Key]
        public int SampleSourceID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [JsonIgnore]
        public required bool IsActive { get; set; } = true;
    }
}
