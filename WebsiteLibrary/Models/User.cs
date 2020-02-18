using System;
using Microsoft.AspNetCore.Identity;

namespace WebsiteLibrary.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string ImageName { get; set; }
    }
}
