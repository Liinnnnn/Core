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
        public IActionResult Login()
        {
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
