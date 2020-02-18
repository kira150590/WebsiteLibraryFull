using System;
using System.Collections.Generic;

namespace WebsiteLibrary.ViewModels
{
    public class BookPageViewModel
    {
        public PaginationViewModel Page { get; set; }

        public IEnumerable<BookViewModel> Books { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; }
    }
}
