using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebsiteLibrary.ViewModels
{
    public class DetailsBookViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Tên Sách: ")]
        public string NameOfBook { get; set; }

        [Display(Name = "Tên Tác Giả: ")]
        public string Author { get; set; }

        [Display(Name = "Năm Xuất Bản: ")]
        public int YearOfPrint { get; set; }

        [Display(Name = "Mã Sách: ")]
        public string Code { get; set; }

        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }

        [Display(Name = "Ảnh: ")]
        public string Photo { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Thể Loại")]
        public int CategoryId { get; set; }
    }
}
