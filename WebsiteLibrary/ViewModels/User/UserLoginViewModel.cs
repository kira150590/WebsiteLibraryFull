using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class UserLoginViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật Khẩu")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        // AuthenticationScheme is in Microsoft.AspNetCore.Authentication namespace
        public List<AuthenticationScheme> ExternalLogins { get; internal set; }

        public static UserLoginViewModel UserLoginView(UserLoginModel userLoginView)
        {
            var a = new UserLoginViewModel();
            a.Id = userLoginView.Id;
            a.Email = userLoginView.Email;
            a.Password = userLoginView.Password;
            a.ReturnUrl = userLoginView.ReturnUrl;

            return a;
        }

        public static IEnumerable<UserLoginViewModel> UserLoginViews(IEnumerable<UserLoginModel> users)
        {
            List<UserLoginViewModel> userViews = new List<UserLoginViewModel>();

            for (int i = 0; i < users.Count(); i++)
            {
                userViews.Add(UserLoginView(users.ElementAtOrDefault(i)));

            }
            return userViews;
        }
    }
}
