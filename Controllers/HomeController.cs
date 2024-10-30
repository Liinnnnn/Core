using Microsoft.AspNetCore.Mvc;
using projekt1.Data;
using projekt1.Models;
using System.Diagnostics;
using Film = projekt1.Data.Film;

namespace projekt1.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaDbContext db;
        
        public HomeController(CinemaDbContext context)
        {
            db = context;
        }
      
        public IActionResult Index()    
        {
            var films = db.Films.ToList();   
            var fiml1 = db.Films.FirstOrDefault();
            return View(films);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
