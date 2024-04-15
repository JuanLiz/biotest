using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class AnalysisType
    {
        [Key]
        public int AnalysisTypeID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
