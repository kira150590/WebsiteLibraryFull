using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class UserRegistrationViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu *")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
        [Display(Name = "Xác nhận mật khẩu *")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Họ *")]
        public string FirstName { get; set; }
        //public string FirstName2 { get; set; }

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

        public static UserRegistrationViewModel UserRegistrationView(UserRegistrationModel userRegistrationView)
        {
            var a = new UserRegistrationViewModel();
            a.Id = userRegistrationView.Id;
            a.Password = userRegistrationView.Password;
            a.ConfirmPassword = userRegistrationView.ConfirmPassword;
            a.FirstName = userRegistrationView.FirstName;
            a.LastName = userRegistrationView.LastName;
            a.Email = userRegistrationView.Email;
            a.Address = userRegistrationView.Address;
            a.Province = userRegistrationView.Province;
            a.District = userRegistrationView.District;
            a.Image = userRegistrationView.Image;

            return a;
        }

        public static IEnumerable<UserRegistrationViewModel> UserViews(IEnumerable<UserRegistrationModel> users)
        {
            List<UserRegistrationViewModel> userViews = new List<UserRegistrationViewModel>();

            for (int i = 0; i < users.Count(); i++)
            {
                userViews.Add(UserRegistrationView(users.ElementAtOrDefault(i)));

            }
            return userViews;
        }


    }
}
