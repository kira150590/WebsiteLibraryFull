using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string Province { get; set; }

        public string District { get; set; }

        public string ImageName { get; set; }

        public static UserViewModel UserView(User userView)
        {
            var a = new UserViewModel();
            a.Id = userView.Id;
            a.Password = userView.PasswordHash;
            a.FirstName = userView.FirstName;
            a.LastName = userView.LastName;
            a.Email = userView.Email;
            a.Address = userView.Address;
            a.Province = a.Province;
            a.District = a.District;
            a.ImageName = userView.ImageName;

            return a;
        }

        public static IEnumerable<UserViewModel> UserViews(IEnumerable<User> users)
        {
            List<UserViewModel> userViews = new List<UserViewModel>();

            for (int i = 0; i < users.Count(); i++)
            {
                userViews.Add(UserView(users.ElementAtOrDefault(i)));

            }
            return userViews;
        }

        
    }
}
