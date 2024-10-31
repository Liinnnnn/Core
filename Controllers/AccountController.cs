using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using projekt1.Data;
using projekt1.Models;

namespace projekt1.Controllers
{
    public class AccountController : Controller
    {
        private readonly CinemaDbContext db;

        public AccountController(CinemaDbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login login, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var account = db.Users.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);
                if (account == null)
                {

                    ModelState.AddModelError("Lỗi", "Thông tin đăng nhập không chính xác");
                }
                else
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,account.Email),
                        new Claim(ClaimTypes.Role,"user")
                    };
                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                    HttpContext.Session.SetInt32("UserId", account.UserId);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);

                    }
                    else
                    {
                        return Redirect("/Home");
                    }
                }

            }
            return View();
        }
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register register, IFormFile file)
        {

            if (file != null && file.Length > 0)
            {
                // Lưu file vào thư mục wwwroot/images
                var filePath_root = Path.Combine("wwwroot/img/User", file.FileName);
                var filePath_db = Path.Combine("/img/User", file.FileName);
                using (var stream = new FileStream(filePath_root, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Lưu thông tin file vào cơ sở dữ liệu
                User user = new User(register.FullName, register.BirthDay, register.Gender, register.PhoneNumber, filePath_db, register.Email, register.Password, "User");

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                }
            }
            else
            {
                var defaultImg = Path.Combine("/img/User", "defaultAvatar.jpg");
                User user = new User(register.FullName, register.BirthDay, register.Gender, register.PhoneNumber, defaultImg, register.Email, register.Password, "User");

                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    await db.SaveChangesAsync();
                }
            }

            return View();
        }
    }
}
