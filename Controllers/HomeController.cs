using Microsoft.AspNetCore.Mvc;
using projekt1.Models;
using System.Diagnostics;

namespace projekt1.Controllers
{
    public class HomeController : Controller
    {
        private List<Film> films = new List<Film>();
        public HomeController()
        {
            films = new List<Film>()
            {
                new Film()
                {
                  Name ="Cám",
                  Link = "/img/film/tam.jpg",
                  Status = "Đang chiếu",
                  Description = "Câu chuyện phim là dị bản kinh dị đẫm máu lấy cảm hứng từ truyện cổ tích nổi tiếng Tấm Cám, nội dung chính của phim xoay quanh Cám - em gái cùng cha khác mẹ của Tấm đồng thời sẽ có nhiều nhân vật và chi tiết sáng tạo, gợi cảm giác vừa lạ vừa quen cho khán giả..",
                  Filter = "ongoing"
                },
                new Film()
                {
                  
                },
            };
        }
      
        public IActionResult Index()
        {
            return View(films);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
