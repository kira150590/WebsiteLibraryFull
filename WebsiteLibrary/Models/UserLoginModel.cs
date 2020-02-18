using System;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
