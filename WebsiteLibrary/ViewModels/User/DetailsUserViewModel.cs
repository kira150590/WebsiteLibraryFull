using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteLibrary.ViewModels
{
    public class DetailsUserViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Mật Khẩu: ")]
        public string PassWord { get; set; }

        [Display(Name = "Họ: ")]
        public string FirstName { get; set; }

        [Display(Name = "Tên: ")]
        public string LastName { get; set; }

        [Display(Name = "Ngày Sinh: ")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Display(Name = "Địa Chỉ: ")]
        public string Address { get; set; }

        [Display(Name = "Tỉnh - TP: ")]
        public string Province { get; set; }

        [Display(Name = "Quận - Huyện: ")]
        public string District { get; set; }

        [Display(Name = "Ảnh: ")]
        public string Photo { get; set; }
    }
}
