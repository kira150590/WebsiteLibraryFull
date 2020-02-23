using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace WebsiteLibrary.Models
{
    public class UserLoginModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public List<AuthenticationScheme> ExternalLogins { get; internal set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
