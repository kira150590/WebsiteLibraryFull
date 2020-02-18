using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string NameOfBook { get; set; }

        public string Author { get; set; }

        public int YearOfPrint { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public string CategoryName { get; set; }

        public string ImageName { get; set; }

        public static BookViewModel BookView(Book bookView)
        {
            var a = new BookViewModel();
            a.NameOfBook = bookView.NameOfBook;
            a.Author = bookView.Author;
            a.Id = bookView.Id;
            a.YearOfPrint = bookView.YearOfPrint;
            a.Code = bookView.Code;
            a.Quantity = bookView.Quantity;
            a.CategoryName = bookView.Category.CategoryName;
            a.ImageName = bookView.ImageName;
            return a;
        }

        public static IEnumerable<BookViewModel> BookViews(IEnumerable<Book> books)
        {
            List<BookViewModel> bookViews = new List<BookViewModel>();
            for (int i = 0; i < books.Count(); i++)
            {
                bookViews.Add(BookView(books.ElementAtOrDefault(i)));
            }

            return bookViews;
        }
    }
}
