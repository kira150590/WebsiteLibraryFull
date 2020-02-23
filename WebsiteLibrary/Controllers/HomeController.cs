using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebsiteLibrary.Models;
using Microsoft.AspNetCore.Hosting;
using WebsiteLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebsiteLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WebsiteLibraryContext _dbContext;

        private readonly IWebHostEnvironment _webHostingEnvironment;

        public HomeController(WebsiteLibraryContext dbContext, ILogger<HomeController> logger, IWebHostEnvironment webHostingEnvironment,
            SignInManager<User> signInManager)
        {
            _dbContext = dbContext;
            _logger = logger;
            _webHostingEnvironment = webHostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BookVisitorUser(string searchString, string sortOrder, int? category, int currentPage = 1, int pageSize = 5)
        {

            #region search

            IQueryable<Book> books = _dbContext.BooksList.Include(x => x.Category);

            IQueryable<Category> categories = _dbContext.CategoriesList;


            if (category.HasValue)
            {
                books = books.Where(x => x.CategoryId == category);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.NameOfBook.Contains(searchString)
                || s.Author.Contains(searchString)
                || s.Code.Contains(searchString));
            }

            #endregion

            #region Phần tử
            int totalItems = books.Count();
            int totalPages;
            if (totalItems / pageSize == 0)
            {
                totalPages = totalItems / pageSize;
            }
            else
            {
                totalPages = (totalItems / pageSize) + 1;
            }

            if (currentPage > totalPages)
            {
                currentPage = totalPages;
                if (currentPage == 0)
                {
                    currentPage = 1;
                }
            }
            #endregion

            #region Số trang trước sau
            int startPage = 1;
            int endPage = totalPages;
            int displayPage = 6;
            bool isOdd = displayPage % 2 != 0;
            int leftPage = displayPage / 2;
            int rightPage = displayPage / 2;

            if (!isOdd)
            {
                rightPage = (int)Math.Floor((decimal)displayPage / 2);
                leftPage = rightPage - 1;
            }

            if (currentPage <= startPage + leftPage)
            {
                endPage = startPage + (displayPage - 1);
            }
            else if (currentPage >= endPage - rightPage)
            {
                startPage = endPage - (displayPage - 1);
            }
            else
            {
                startPage = currentPage - leftPage;
                endPage = currentPage + rightPage;
            }

            if (endPage > totalPages)
            {
                endPage = totalPages;
            }

            if (startPage < 1)
            {
                startPage = 1;
            }
            #endregion

            #region Tạo Sắp Xếp Giá Trị 1 Thuộc Tính

            ViewBag.SortNameBook = String.IsNullOrEmpty(sortOrder) ? "name_desc" : string.Empty;

            ViewBag.SortAuthor = sortOrder == "author_asc" ? "author_desc" : "author_asc";
            ViewBag.SortYear = sortOrder == "year_asc" ? "year_desc" : "year_asc";
            ViewBag.SortCode = sortOrder == "code_asc" ? "code_desc" : "code_asc";
            ViewBag.SortQuantity = sortOrder == "quantity_asc" ? "quantity_desc" : "quantity_asc";
            ViewBag.SortCategory = sortOrder == "category_asc" ? "category_desc" : "category_asc";

            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.NameOfBook);
                    break;

                case "author_desc":
                    books = books.OrderByDescending(s => s.Author);
                    break;
                case "author_asc":
                    books = books.OrderBy(s => s.Author);
                    break;

                case "year_desc":
                    books = books.OrderByDescending(s => s.YearOfPrint);
                    break;
                case "year_asc":
                    books = books.OrderBy(s => s.YearOfPrint);
                    break;

                case "code_desc":
                    books = books.OrderByDescending(s => s.Code);
                    break;
                case "code_asc":
                    books = books.OrderBy(s => s.Code);
                    break;

                case "quantity_desc":
                    books = books.OrderByDescending(s => s.Quantity);
                    break;
                case "quantity_asc":
                    books = books.OrderBy(s => s.Quantity);
                    break;

                case "category_desc":
                    books = books.OrderByDescending(s => s.Category.CategoryName);
                    break;
                case "category_asc":
                    books = books.OrderBy(s => s.Category.CategoryName);
                    break;
                default:
                    books = books.OrderBy(s => s.NameOfBook);
                    break;
            }
            #endregion

            books = books.Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            return View(new BookPageViewModel
            {
                Page = new PaginationViewModel
                {
                    CurrentPage = currentPage,
                    EndPage = endPage,
                    StartPage = startPage,
                    TotalPages = totalPages,
                    PageSize = pageSize
                },
                Books = BookViewModel.BookViews(books),

                Categories = CategoryViewModel.CategoryViews(categories),
            });
        }

        [HttpGet]
        public IActionResult DetailsBookBookVisitorUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var currentBook = _dbContext.BooksList.FirstOrDefault(x => x.Id == id);

                ViewBag.Categories = _dbContext.CategoriesList.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = $"{x.Id}",
                    Selected = currentBook.CategoryId == x.Id
                }).ToList();

                return View(new DetailsBookViewModel
                {
                    Id = currentBook.Id,
                    Code = currentBook.Code,
                    Author = currentBook.Author,
                    CategoryId = currentBook.CategoryId,
                    NameOfBook = currentBook.NameOfBook,
                    Quantity = currentBook.Quantity,
                    YearOfPrint = currentBook.YearOfPrint,
                    Photo = currentBook.ImageName,
                });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsBookBookVisitorUser(int id, DetailsBookViewModel detailsBook)
        {
            var book = await _dbContext.BooksList.FindAsync(detailsBook.Id);

            if (book == null)
            {
                ModelState.AddModelError(string.Empty, "Không có sách trong kho");
            }
            else
            {
                book.Id = detailsBook.Id;
                book.NameOfBook = detailsBook.NameOfBook;
                book.Author = detailsBook.Author;
                book.YearOfPrint = detailsBook.YearOfPrint;
                book.CategoryId = detailsBook.CategoryId;
                book.Quantity = detailsBook.Quantity;
                book.Code = detailsBook.Code;
                book.ImageName = detailsBook.Photo;
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _dbContext.CategoriesList.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = $"{x.Id}",
                    Selected = book.CategoryId == x.Id
                }).ToList();

                return View(detailsBook);
            }

            return RedirectToAction("BookVisitorUser");
        }
    }
}
