using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebsiteLibrary.Models
{
    public class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
