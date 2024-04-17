using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class GeneticTestType
    {
        [Key]
        public int GeneticTestTypeID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;
    }
}
