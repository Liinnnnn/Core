using System.ComponentModel.DataAnnotations;

namespace projekt1.Models
{
    public class ChangePassword
    {

        [Required, DataType(DataType.Password), Display(Name ="Nhập mật khẩu hiện tại")]
        public string CurrentPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Nhập mật khẩu mới")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự!")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_]).{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, có chữ hoa, chữ thường, số và kí tự đặc biệt")]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Nhập lại mật khẩu")]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu không khớp. Thử lại")]
        public string? ConfirmPassword { get; set; }

        public ChangePassword() { }

    }
}
