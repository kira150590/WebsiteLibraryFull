using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebsiteLibrary.ViewModels
{
    public class UpdateBookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 500, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Tên Sách *")]
        public string NameOfBook { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 500, MinimumLength = 1, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Tên Tác Giả *")]
        public string Author { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [Range(1, Int32.MaxValue)]
        [Display(Name = "Năm Xuất Bản *")]
        public int YearOfPrint { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [StringLength(maximumLength: 20, MinimumLength = 4, ErrorMessage = "{0} Không được nhỏ hơn {2} và vượt quá {1}")]
        [Display(Name = "Mã Sách *")]
        public string Code { get; set; }

        [Required(ErrorMessage = "{0} Không được để trống")]
        [Range(1, Int32.MaxValue)]
        [Display(Name = "Số Lượng *")]
        public int Quantity { get; set; }

        [Display(Name = "Ảnh")]
        public string Photo { get; set; }

        public IFormFile Image { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Thể Loại *")]
        [Required(ErrorMessage = "{0} Không được để trống")]
        public int CategoryId { get; set; }
    }
}
