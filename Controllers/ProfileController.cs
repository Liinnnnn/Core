using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using projekt1.Data;
using projekt1.Models;


namespace projekt1.Controllers
{
    public class ProfileController : Controller
    {
        private readonly CinemaDbContext db;

        public ProfileController(CinemaDbContext context)
        {
            db = context;
        }

        [HttpGet]       
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

        [HttpPost]
        public async Task<IActionResult> Profile(User user, IFormFile file)
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId != null)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.UserId == userId);

                if (existingUser != null)
                {
                    existingUser.FullName = user.FullName;
                    existingUser.BirthDay = user.BirthDay;
                    existingUser.PhoneNumber = user.PhoneNumber;

                    if (file != null && file.Length > 0)
                    {
                        var filePath_root = Path.Combine("wwwroot/img/User", file.FileName);

                        var filePath_db = Path.Combine("/img/User", file.FileName);

                        using (var stream = new FileStream(filePath_root, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }

                        existingUser.AvatarImg = filePath_db;
                        
                    }
                    
                    db.Users.Update(existingUser);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Profile");
                }
            }

            return View();
        }
    }
}
