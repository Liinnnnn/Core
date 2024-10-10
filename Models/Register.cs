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
        [Range(typeof(DateOnly),"1/1/1960","12/31/2006",ErrorMessage ="Xin vui lòng nhập ngày sinh trong khoảng 1/1/1960 đến 12/31/2006")]
        public DateOnly BirthDay { get; set; }

        [Display(Name = "Giới Tính")]
        public string? Gender { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [Required(ErrorMessage = "*")]
        //[RegularExpression(@"((^(\+84 | 84 | 0 | 0084){1})(3|5|7|8|9))+([0 - 9]{8})$)",ErrorMessage ="Xin nhập đúng định dạng số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tải Ảnh Lên")]
        [DataType(DataType.Url)]
        public string? AvatarImg { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Chưa đúng định dạng")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$", ErrorMessage = "Xin nhập đúng định dạng email")]
        public string Email { get; set; }

        [Display(Name = "Mật Khẩu")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự!")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).{8,}$", ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, có chữ hoa, chữ thường, số và kí tự đặc biệt")]
        public string Password { get; set; }

        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Mật khẩu không khớp. Thử lại")]
        [Display(Name = "Nhập Lại Mật Khẩu")]
        public string Confirmpassword { get; set; }
    }
}
