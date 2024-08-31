using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [DataType("varchar")]
        [MaxLength(50)]
        [Required]
        [Display(Name ="Emplo N")]
        public string Name { get; set; } = null!;
        [DataType("varchar")]
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = null!;


    }
}
