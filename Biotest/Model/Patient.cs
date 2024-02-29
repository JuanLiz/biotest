using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Patient

    {
        [Key]
        public required int PatientID { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        public required int GenderID { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }

        [ForeignKey("GenderID")]
        public required Gender Gender { get; set; }

    }
}
