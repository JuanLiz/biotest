using System.ComponentModel.DataAnnotations;

namespace Biotest.Model
{
    public class EmployeePosition
    {
        [Key]
        public int EmployeePositionID { get; set; }
        public required string Name { get; set; }
    }
}
