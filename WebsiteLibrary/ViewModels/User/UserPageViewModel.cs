using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteLibrary.Models;
using WebsiteLibrary.ViewModels;

namespace WebsiteLibrary.ViewModels
{
    public class UserPageViewModel
    {
        public PaginationViewModel Page { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
