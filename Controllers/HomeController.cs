using Microsoft.AspNetCore.Mvc;
using projekt1.Data;
using projekt1.Models;
using System.Diagnostics;

namespace projekt1.Controllers
{
    public class HomeController : Controller
    {
       
        private static List<Data.Film> films = new List<Data.Film> { };
        private CinemaDbContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            //_logger = logger;
            _context = new CinemaDbContext();
        }


        public IActionResult Index()  
        {
            var films = _context.Films.ToList();
            return View(films);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
