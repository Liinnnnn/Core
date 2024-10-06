using System;
using System.ComponentModel.DataAnnotations;

namespace projekt1.Models
{
    public class Register
    {
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "*")]
        [MaxLength(50,ErrorMessage = "Tối đa 50 kí tự!")]
        public string FullName { get; set; } = null!;

        [Display(Name = "Ngày Sinh")]
        [DataType(DataType.Date,ErrorMessage = "Nhập Ngày Sinh")]
        public DateOnly BirthDay { get; set; }

        [Display(Name = "Giới Tính")]
        public string? Gender { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "*")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tải Ảnh Lên")]
        [DataType(DataType.Url)]
        public string? AvatarImg { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Chưa đúng định dạng")]
        public string Email { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "*")]
        [Compare("Password",ErrorMessage = "Mật khẩu không khớp. Thử lại")]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        public string Confirmpassword { get; set; }
    }
}
