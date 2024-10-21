using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projekt1.Data;
using projekt1.Models;


namespace projekt1.Controllers
{
    public class ProfileController : Controller
    {
        private readonly CinemaDbContext db;

        public ProfileController()
        {
            db = new CinemaDbContext();
        }
        [Authorize]
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId != null)
            {
                var user = db.Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    return View(user);
                }
            }
            return RedirectToAction("Login", "Account");

        }

    }
}
