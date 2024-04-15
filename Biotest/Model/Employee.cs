using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required int GenderID { get; set; }
        [Required]
        public required int EmployeePositionID { get; set; }

        [ForeignKey("GenderID")]
        public virtual Gender Gender { get; set; }
        [ForeignKey("EmployeePositionID")]
        public virtual EmployeePosition? EmployeePosition { get; set; }

    }
}
