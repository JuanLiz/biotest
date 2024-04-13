using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Patient

    {
        [Key]
        public int PatientID { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required DateOnly BirthDate { get; set; }
        [Required]
        public required int GenderID { get; set; }
        [Required] 
        public required string Phone { get; set; }
        [Required]
        public required string Address { get; set; }
        [Required]
        public required string Email { get; set; }

        [ForeignKey("GenderID")]
        public Gender Gender { get; set; } = null!;

    }
}
