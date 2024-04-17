using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string LastName { get; set; }
        [ForeignKey(nameof(Gender))]
        public required int GenderID { get; set; }
        [ForeignKey(nameof(EmployeePosition))]
        public required int EmployeePositionID { get; set; }
        [JsonIgnore]
        public required bool IsActive { get; set; } = true;


        public virtual Gender? Gender { get; set; }
        public virtual EmployeePosition? EmployeePosition { get; set; }

    }
}
