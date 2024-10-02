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
                    Name = "Quỷ Án",
                    Link = "/img/film/media_images_2024_08_20_q-101323-200824-62.jpg",
                    Status = "Sắp chiếu",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "preview"
                },
                new Film()
                {
                    Name = "Transformer One",
                    Link = "/img/film/media_images_2024_09_11_tf1-intl-allspark-dgtl-online-payoff-keyart-vie-400x633-134254-110924-51.jpg",
                    Status = "Đặc biệt",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "special"
                },
                new Film()
                {
                    Name = "Joker Điên có đôi",
                    Link = "/img/film/media_images_2024_09_19_482wx722h-162630-190924-83.jpg",
                    Status = "Đang chiếu",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "ongoing"
                },
                new Film()
                {
                    Name = "Venom",
                    Link = "/img/film/media_images_2024_09_19_screenshot-2024-09-19-150036-150139-190924-38.png",
                    Status = "Sắp chiếu",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "preview"
                },
                new Film()
                {
                    Name = "Latency",
                    Link = "/img/film/media_images_2024_09_19_screenshot-2024-09-19-154629-154714-190924-43.png",
                    Status = "Đặc biệt",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "special"
                },
                new Film()
                {
                    Name = "Shin",
                    Link = "/img/film/media_images_2024_08_01_38-400x633-182208-010824-97.png",
                    Status = "Đang chiếu",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "ongoing"
                },
                new Film()
                {
                    Name = "Đố anh bắt được em",
                    Link = "/img/film/da.png",
                    Status = "Sắp chiếu",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "preview"
                },
                new Film()
                {
                    Name = "Avenger",
                    Link = "/img/film/R.jpg",
                    Status = "Đặc biệt",
                    Description = "Lorem ipsum, dolor sit amet consectetur",
                    Filter = "special"
                }
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
