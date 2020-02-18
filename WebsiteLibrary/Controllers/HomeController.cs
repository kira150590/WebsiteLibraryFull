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

namespace WebsiteLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly WebsiteLibraryContext _dbContext;

        private readonly IWebHostEnvironment _webHostingEnvironment;

        public HomeController(WebsiteLibraryContext dbContext, ILogger<HomeController> logger, IWebHostEnvironment webHostingEnvironment)
        {
            _dbContext = dbContext;
            _logger = logger;
            _webHostingEnvironment = webHostingEnvironment;
        }

        #region Index
        public IActionResult Index()
        {
            return View();
        }

        #endregion


    }
}
