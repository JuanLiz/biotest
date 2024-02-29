using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Employee
    {
        [Key]
        public required int EmployeeID { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required int GenderID { get; set; }
        public required int EmployeePositionID { get; set; }

        [ForeignKey("GenderID")]
        public required Gender Gender { get; set; }
        [ForeignKey("EmployeePositionID")]
        public required EmployeePosition EmployeePosition { get; set; }

    }
}
