using System.ComponentModel.DataAnnotations;

namespace projekt1.Models
{
    public class Account
    {
        [Required]

        public string Email { get; set; }
        public string Password { get; set; }
    }
}
