using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public static CategoryViewModel CategoryView(Category categoryView)
        {
            var a = new CategoryViewModel();
            a.Id = categoryView.Id;
            a.CategoryName = categoryView.CategoryName;
            return a;
        }

        public static IEnumerable<CategoryViewModel> CategoryViews(IEnumerable<Category> categories)
        {
            List<CategoryViewModel> categoryViews = new List<CategoryViewModel>();
            for (int i = 0; i < categories.Count(); i++)
            {
                categoryViews.Add(CategoryView(categories.ElementAtOrDefault(i)));
            }

            return categoryViews;
        }
    }
}
