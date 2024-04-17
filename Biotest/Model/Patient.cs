using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Biotest.Model
{
    public class Patient

    {
        [Key]
        public int PatientID { get; set; }
        [MaxLength(30)]
        public required string Name { get; set; }
        [MaxLength(30)]
        public required string LastName { get; set; }
        public required DateOnly BirthDate { get; set; }
        [ForeignKey(nameof(Gender))]
        public required int GenderID { get; set; }
        [MaxLength(10)]
        public required string Phone { get; set; }
        [MaxLength(50)]
        public required string Address { get; set; }
        [MaxLength(320)]
        public required string Email { get; set; }
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        public virtual Gender? Gender { get; set; }

    }
}
