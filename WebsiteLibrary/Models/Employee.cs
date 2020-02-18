using System;
using System.ComponentModel.DataAnnotations;

namespace WebsiteLibrary.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string Position { get; set; }
    }
}
