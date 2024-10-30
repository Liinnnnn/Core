using Microsoft.AspNetCore.Mvc;
using projekt1.Data;
using projekt1.Models;
using System.Diagnostics;

namespace projekt1.Controllers
{
    public class HomeController : Controller
    {
        //private List<Film> films = new List<Film>();
        //public HomeController()
        //{
        //    films = new List<Film>()
        //    {
        //        new Film()
        //        {
        //          Name ="Cám",
        //          Link = "/img/film/tam.jpg",
        //          Status = "Đang chiếu",
        //          Description = "Câu chuyện phim là dị bản kinh dị đẫm máu lấy cảm hứng từ truyện cổ tích nổi tiếng Tấm Cám, nội dung chính của phim xoay quanh Cám - em gái cùng cha khác mẹ của Tấm đồng thời sẽ có nhiều nhân vật và chi tiết sáng tạo, gợi cảm giác vừa lạ vừa quen cho khán giả..",
        //          Filter = "ongoing"
        //        },
        //        new Film()
        //        {
        //            Name = "Quỷ Án",
        //            Link = "/img/film/media_images_2024_08_20_q-101323-200824-62.jpg",
        //            Status = "Sắp chiếu",
        //            Description = "Quỷ Án kể về vụ án người phụ nữ Dani bị sát hại dã man tại ngôi nhà mà vợ chồng cô đang sửa sang ở vùng nông thôn hẻo lánh.",
        //            Filter = "preview"
        //        },
        //        new Film()
        //        {
        //            Name = "Transformer One",
        //            Link = "/img/film/media_images_2024_09_11_tf1-intl-allspark-dgtl-online-payoff-keyart-vie-400x633-134254-110924-51.jpg",
        //            Status = "Đặc biệt",
        //            Description = "Câu chuyện khởi nguồn tại hành tinh Cybertron, nơi các robot đang khai thác Energon nhằm tạo ra năng lượng, trước khi cuộc chiến khốc liệt giữa hai phe Decepticons và Autobots bùng nổ.",
        //            Filter = "special"
        //        },
        //        new Film()
        //        {
        //            Name = "Joker: Điên có đôi",
        //            Link = "/img/film/media_images_2024_09_19_482wx722h-162630-190924-83.jpg",
        //            Status = "Đang chiếu",
        //            Description = "Câu chuyện kể về mối tình “tâm giao” cực kỳ méo mó giữa hai kẻ “điên” Joker và Harley Quinn.",
        //            Filter = "ongoing"
        //        },
        //        new Film()
        //        {
        //            Name = "Venom 3",
        //            Link = "/img/film/media_images_2024_09_19_screenshot-2024-09-19-150036-150139-190924-38.png",
        //            Status = "Sắp chiếu",
        //            Description = "Phần 3 của bộ phim Venom: The last dance",
        //            Filter = "preview"
        //        },
        //        new Film()
        //        {
        //            Name = "Latency",
        //            Link = "/img/film/media_images_2024_09_19_screenshot-2024-09-19-154629-154714-190924-43.png",
        //            Status = "Đặc biệt",
        //            Description = "Bộ phim kinh dị điện ảnh Mỹ kết nối tử thần",
        //            Filter = "special"
        //        },
        //        new Film()
        //        {
        //            Name = "Shin",
        //            Link = "/img/film/media_images_2024_08_01_38-400x633-182208-010824-97.png",
        //            Status = "Đang chiếu",
        //            Description = "Phim hoạt hình cậu bé bút chì: nhật kí khủng long của chúng mình",
        //            Filter = "ongoing"
        //        },
        //        new Film()
        //        {
        //            Name = "Đố anh bắt được em",
        //            Link = "/img/film/da.png",
        //            Status = "Sắp chiếu",
        //            Description = "I, The Executioner kể về cuộc truy đuổi tên sát nhân hàng loạt gây chấn động xã hội của đội điều tra tội phạm nghiêm trọng.",
        //            Filter = "preview"
        //        },
        //        new Film()
        //        {
        //            Name = "Avenger ENDGAME",
        //            Link = "/img/film/R.jpg",
        //            Status = "Đặc biệt",
        //            Description = "Bộ phim khép lại giai đoạn 3 của vũ trụ điện ảnh Marvel (MCU), đồng thời cũng là phần kết cho mạch truyện xoay quanh 6 viên đá vô cực. ",
        //            Filter = "special"
        //        }
        //    };

        //}
        private static List<Data.Film> films = new List<Data.Film> { };
        private CinemaDbContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
           // _logger = logger;
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
