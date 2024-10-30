using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projekt1.Data;

namespace projekt1.Controllers
{
    public class FilmController : Controller
    {
        //[Authorize]
        private static List<Film> films = new List<Film> { };
        private CinemaDbContext _context;

        public FilmController(CinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet("Film/Index/ {id}")]
        public IActionResult Index(int id)
        {
            //var film = _context.Films.FirstOrDefault(f => f.FilmId == id);
            //if (film == null) return NotFound();
            //return View(film);

            // Ngày hiện tại
            DateTime today = DateTime.Today;

            // Ngày kết thúc (7 ngày kể cả hôm nay)
            DateTime endDate = today.AddDays(6);
            // Truy vấn phim và suất chiếu liên quan
            var film = _context.Films
                .Include(f => f.Showtimes)  // Lấy các suất chiếu liên quan
                .FirstOrDefault(f => f.FilmId == id);

            if (film == null)
                return NotFound();


            film.Showtimes = film.Showtimes
             .Where(s => s.ShowtimeDate.HasValue &&
                    s.ShowtimeDate.Value.Date >= today &&
                    s.ShowtimeDate.Value.Date <= endDate)
        .OrderBy(s => s.ShowtimeDate) // Sắp xếp theo ngày chiếu
        .ToList();

            return View(film);  // Truyền dữ liệu phim và suất chiếu sang View


        }
    }
}

