using System.Security.Claims;
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
            if(ModelState.IsValid)
            {
                var account = db.Accounts.FirstOrDefault(a => a.Email == login.Email && a.Password == login.Password);
                if(account == null)
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

                    if(Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);

                    }
                    else
                    {
                        return Redirect("/Film");
                    }

                }
                
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {

            User user = new User(register.FullName, register.BirthDay, register.Gender, register.PhoneNumber, register.AvatarImg);
            Account account = new Account(register.Email, register.Password,"User");


            if(ModelState.IsValid)
            {
                db.Users.Add(user);
                db.Accounts.Add(account);
                db.SaveChanges();
            }
            return View();
        }
    }
}
