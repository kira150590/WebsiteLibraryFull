using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebsiteLibrary.Models
{
    public class UserRegistrationModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Họ *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Tên *")]
        public string LastName { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 8, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        [Display(Name = "Ảnh")]
        public IFormFile Image { get; set; }
    }
}
