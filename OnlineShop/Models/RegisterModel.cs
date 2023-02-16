using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name= "Tên đăng nhập")]
        [Required(ErrorMessage ="Yêu cầu nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(32,MinimumLength = 6, ErrorMessage = "Độ dài ít nhất 6 ký tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string Password { get; set; }

        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("Password", ErrorMessage ="Xác nhận mật khẩu không đúng")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tên ")]
        [Required(ErrorMessage = "Yêu cầu nhập tên ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Display(Name = " Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string Mobile { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Giới tính")]
        public bool Sex { get; set; }
        public string Phone { get; internal set; }
    }
}