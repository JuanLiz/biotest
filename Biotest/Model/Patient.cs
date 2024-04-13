using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biotest.Model
{
    public class Patient

    {
        [Key]
        public int PatientID { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public int GenderID { get; set; }
        [Required] 
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        [ForeignKey("GenderID")]
        public Gender? Gender { get; set; }

    }
}
