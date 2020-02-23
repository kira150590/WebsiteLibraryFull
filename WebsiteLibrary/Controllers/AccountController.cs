using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebsiteLibrary.Models;
using WebsiteLibrary.ViewModels;

namespace WebsiteLibrary.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebsiteLibraryContext _dbContext;
        private readonly IWebHostEnvironment _webHostingEnvironment;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<HomeController> logger,
                                IWebHostEnvironment webHostingEnvironment, WebsiteLibraryContext dbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _webHostingEnvironment = webHostingEnvironment;
        }

        //[Authorize(Roles = "Administrator")]
        public IActionResult Users(string searchString, string sortOrder, int currentPage = 1, int pageSize = 5)
        {
            bool a = User.IsInRole("User");
            bool b = User.IsInRole("Administrator");
            bool c = User.IsInRole("Visitor");
            #region search

            IQueryable<User> users = _dbContext.Users;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.UserName.Contains(searchString)
                || s.Email.Contains(searchString)
                || s.PhoneNumber.Contains(searchString));
            }

            #endregion

            #region Phần tử
            int totalItems = users.Count();
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

            ViewBag.SortUserName = String.IsNullOrEmpty(sortOrder) ? "username_desc" : string.Empty;

            ViewBag.SortPhoneNumber = sortOrder == "phone_asc" ? "phone_asc" : "phone_asc";
            ViewBag.SortEmail = sortOrder == "email_desc" ? "email_desc" : "email_desc";
            ViewBag.SortDistrict = sortOrder == "district_asc" ? "district_asc" : "district_asc";
            ViewBag.SortAddress = sortOrder == "address_desc" ? "address_desc" : "address_desc";
            ViewBag.Sortprovince = sortOrder == "province_desc" ? "province_desc" : "province_desc";


            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.UserName);
                    break;

                case "phone_desc":
                    users = users.OrderByDescending(s => s.PhoneNumber);
                    break;
                case "phone_asc":
                    users = users.OrderBy(s => s.PhoneNumber);
                    break;

                case "email_desc":
                    users = users.OrderByDescending(s => s.Email);
                    break;
                case "email_asc":
                    users = users.OrderBy(s => s.Email);
                    break;

                case "address_desc":
                    users = users.OrderByDescending(s => s.Address);
                    break;
                case "address_asc":
                    users = users.OrderBy(s => s.Address);
                    break;

                case "province_desc":
                    users = users.OrderByDescending(s => s.Province);
                    break;
                case "province_asc":
                    users = users.OrderBy(s => s.Province);
                    break;

                case "category_desc":
                    users = users.OrderByDescending(s => s.District);
                    break;
                case "category_asc":
                    users = users.OrderByDescending(s => s.District);
                    break;
                default:
                    users = users.OrderBy(s => s.UserName);
                    break;
            }
            #endregion

            users = users.Skip((currentPage - 1) * pageSize)
                    .Take(pageSize);

            return View(new UserPageViewModel
            {
                Page = new PaginationViewModel
                {
                    CurrentPage = currentPage,
                    EndPage = endPage,
                    StartPage = startPage,
                    TotalPages = totalPages,
                    PageSize = pageSize
                },

                Users = UserViewModel.UserViews(users)
            });
        }

        #region Delete User
        [HttpPost]
        public JsonResult AjaxDeleteUser(string id)
        {
            _dbContext.Entry(new User()
            {
                Id = id
            }).State = EntityState.Deleted;

            _dbContext.SaveChanges();

            return Json(true);
        }

        [HttpPost]
        public JsonResult DeleteManyUser(List<string> ids)
        {
            try
            {
                if (ids == null || ids.Count == 0)
                {
                    Response.StatusCode = 400;
                }
                else
                {
                    ids.ForEach(id => _dbContext.Entry(new User
                    {
                        Id = id
                    }).State = EntityState.Deleted);

                    _dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                Response.StatusCode = 500;

            }

            return Json(string.Empty);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult DetailsUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var currentUser = _dbContext.Users.FirstOrDefault(x => x.Id == id);

                return View(new DetailsUserViewModel
                {
                    Id = currentUser.Id,
                    Email = currentUser.Email,
                    Address = currentUser.Address,
                    Province = currentUser.Province,
                    District = currentUser.District,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    Photo = currentUser.ImageName,
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsUser(string id, DetailsUserViewModel detailsUser)
        {
            var user = await _dbContext.Users.FindAsync(detailsUser.Id);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Không có User");
            }
            else
            {
                user.Id = detailsUser.Id;
                user.Email = detailsUser.Email;
                user.LastName = detailsUser.LastName;
                user.FirstName = detailsUser.FirstName;
                user.Address = detailsUser.Address;
                user.Province = detailsUser.Province;
                user.District = detailsUser.District;
                user.ImageName = detailsUser.Photo;
            }

            if (!ModelState.IsValid)
            {
                return View(detailsUser);
            }

            return RedirectToAction("Users");
        }
        #endregion

        #region Register + Login + Logout

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Province = _dbContext.Provinces.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            return View();
        }

        [HttpGet]
        public JsonResult GetDistricts(int provinceId)
        {
            var temp = _dbContext.Districts.Where(x => x.ProvinceId == provinceId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
            }).ToList();

            return Json(temp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationViewModel userModel, int provinceId, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Province = _dbContext.Provinces.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                var temp = _dbContext.Districts.Where(x => x.ProvinceId == provinceId).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                }).ToList();

                return View(userModel);
            }

            var user = _mapper.Map<User>(userModel);

            //lấy phần trước của Email làm userName login
            //user.UserName = user.Email.Split('@')[0];
            //anh dang lam` dang nhap = email roi, cai nay` phai? config lai. cơ mà em quên config sao rồi :))
            //hm, h sao ta
            //tạm thời lấy phần trc của email = user name nhé anh
            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                ViewBag.Province = _dbContext.Provinces.Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

                //à vs lại, case not success của anh đang lỗi, vì thiếu ViewBag đoạn đó
                //phải có ở trc mấy chỗ return lại trang view cũ nếu ko sẽ bị lỗi
                //tát nhiên là có cách cho đỡ viết nhiều quá như vậy
                //cơ mà chừng nào trình advance rồi thì em chỉ cho :))

                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                string uniqueFileName = null;
                if (userModel.Image != null)
                {
                    string uploadsFolder = Path.Combine(_webHostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + userModel.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    userModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                return View(userModel);
            }

            await _userManager.AddToRoleAsync(user, "User");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            UserLoginViewModel model = new UserLoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginViewModel userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(userModel);
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("", "Kiểm tra lại Email hoặc Mật khẩu");
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            //await _signInManager.SignOutAsync();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion

        #region Login with FB, GG
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                                    new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl ??= Url.Content("~/");

            UserLoginViewModel userLoginViewModel = new UserLoginViewModel
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"Lỗi từ nick đăng nhập Fb hoặc Google: {remoteError}");

                return View("Login", userLoginViewModel);
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                ModelState.AddModelError(string.Empty, "Không tải được thông tin đăng nhập");

                return View("Login", userLoginViewModel);
            }
            
            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider,
                                        info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (email != null)
                {
                    var user = await _userManager.FindByEmailAsync(email);
                    if (user == null)
                    {

                        user = new User
                        {
                            UserName = info.Principal.FindFirstValue(ClaimTypes.Email),
                            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await _userManager.CreateAsync(user);
                    }

                    await _userManager.AddLoginAsync(user, info);
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
                ViewBag.ErrorTitle = $"Email claim not received from: {info.LoginProvider}";
                ViewBag.ErrorMessage = "Please contact support";

                return View("Error");
            }
        }
        #endregion

    }
}