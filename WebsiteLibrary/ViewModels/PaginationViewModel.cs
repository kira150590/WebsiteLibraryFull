using System;
namespace WebsiteLibrary.ViewModels
{
    public class PaginationViewModel
    {
        public PaginationViewModel()
        {
            DisplayPage = 5;
            PageSize = 5;
            CurrentPage = 1;
        }

        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }
        public int DisplayPage { get; set; }
    }
}
