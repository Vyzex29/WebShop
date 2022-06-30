using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class SignInUserModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
