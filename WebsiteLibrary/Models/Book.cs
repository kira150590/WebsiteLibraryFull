using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 500, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        public string NameOfBook { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 500, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        public string Author { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [Range(1, Int32.MaxValue)]
        public int YearOfPrint { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [Range(1, Int32.MaxValue)]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        public int CategoryId { get; set; }

        public string ImageName { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
