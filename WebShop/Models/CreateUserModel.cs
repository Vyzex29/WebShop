using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class CreateUserModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(80)]
        [Display(Name = "Username:")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password:")]
        public string RepeatPassword { get; set; }

    }
}
