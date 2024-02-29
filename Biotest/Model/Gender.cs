using System.ComponentModel.DataAnnotations;
namespace Biotest.Model
{
    public class Gender
    {
        [Key]
        public int GenderID { get; set; }
        public required string Name { get; set; }
    }
}
