using System.ComponentModel.DataAnnotations;
namespace Biotest.Model
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
