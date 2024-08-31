using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = "plz enter user name")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]

        [Required(ErrorMessage = "plz enter Password")]
        public string Password { get; set; }

        public bool  IsActive { get; set; }

        public DateTime Created { get; set; }

    }
}
