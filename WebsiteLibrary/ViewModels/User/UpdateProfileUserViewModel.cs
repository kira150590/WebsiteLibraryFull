using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebsiteLibrary.ViewModels
{
    public class UpdateProfileUserViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Tên Đăng Nhập *")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu *")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Họ *")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Tên *")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 11, MinimumLength = 10, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Số Điện Thoại *")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ngày Sinh")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 50, MinimumLength = 10, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 8, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Địa Chỉ")]
        public string Address { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 8, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        public string Province { get; set; }

        [StringLength(maximumLength: 200, MinimumLength = 8, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        public string District { get; set; }

        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        public IFormFile Image { get; set; }
    }
}
