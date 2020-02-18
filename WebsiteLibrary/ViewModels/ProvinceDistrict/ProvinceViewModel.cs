using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteLibrary.Models;

namespace WebsiteLibrary.ViewModels
{
    public class ProvinceViewModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public static ProvinceViewModel ProvinceView(Province provinceView)
        {
            var a = new ProvinceViewModel();
            a.Id = provinceView.Id;
            a.Code = provinceView.Code;
            a.Name = provinceView.Name;
            return a;
        }

        public static IEnumerable<ProvinceViewModel> ProvinceViews(IEnumerable<Province> provinces)
        {
            List<ProvinceViewModel> provinceViews = new List<ProvinceViewModel>();
            for (int i = 0; i < provinces.Count(); i++)
            {
                provinceViews.Add(ProvinceView(provinces.ElementAtOrDefault(i)));
            }

            return provinceViews;
        }
    }
}
