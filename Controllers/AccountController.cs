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
        public IActionResult Register(Register register)
        {

            var check = db.Users.FirstOrDefault(u => u.Email == register.Email);
            if(check == null)
            {
                User user = new User(register.FullName, register.BirthDay, register.Gender, register.PhoneNumber, register.AvatarImg, register.Email, register.Password, "User");

                if(ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                return View("Login");
            }
            return View();
        }
    }
}
