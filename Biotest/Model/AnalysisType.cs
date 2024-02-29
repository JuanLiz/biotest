using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class AnalysisType
    {
        [Key]
        public required int AnalysisTypeID { get; set; }
        public required string Name { get; set; }
    }
}
