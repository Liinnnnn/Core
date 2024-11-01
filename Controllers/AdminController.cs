using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projekt1.Data;

namespace projekt1.Controllers
{
    public class AdminController : Controller
    {
        private CinemaDbContext db = new CinemaDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpdateFilm()
        {
            var films = new List<SelectListItem>();
            var f = db.Films.ToList();
            foreach (var film in db.Films)
            {
                films.Add(new SelectListItem { Text = film.Name, Value = film.FilmId.ToString() });
            }
            ViewBag.FilmId = films;
            return View(f);
        }
        [HttpGet]
        public IActionResult AddFilm()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddFilmAsync(Film film, IFormFile file1, IFormFile file2)
        {


            var filePath_root1 = Path.Combine("wwwroot/img/film", file1.FileName);

            var filePath_db1 = Path.Combine("/img/film", file1.FileName);

            using (var stream = new FileStream(filePath_root1, FileMode.Create))
            {
                await file1.CopyToAsync(stream);
            }

            var filePath_root2 = Path.Combine("wwwroot/img/film", file2.FileName);

            var filePath_db2 = Path.Combine("/img/film", file2.FileName);

            using (var stream = new FileStream(filePath_root2, FileMode.Create))
            {
                await file1.CopyToAsync(stream);
            }

            film.FilmImg = filePath_db1;
            film.BannerImg = filePath_db2;

            db.Films.Add(film);
            db.SaveChanges();



            return View();
        }

    }
}