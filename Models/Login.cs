using System.ComponentModel.DataAnnotations;

namespace projekt1.Models
{
    public class Login
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
