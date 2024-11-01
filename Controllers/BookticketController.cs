using Microsoft.AspNetCore.Mvc;
using projekt1.Data;

namespace projekt1.Controllers
{
    public class BookticketController : Controller
    {
        private readonly CinemaDbContext db;

        public BookticketController(CinemaDbContext context)
        {
            db = context;
        }

        public IActionResult BookTicket(int filmId)
        {
            var film = db.Films.FirstOrDefault(f => f.FilmId == filmId);
            if (film == null) return NotFound();

            // Lấy danh sách showtimes cho phim
            var showtimes = db.Showtimes.Where(s => s.FilmID == filmId).ToList();
            ViewBag.Showtimes = showtimes;

            // Trả về view đặt vé kèm theo thông tin của phim
            return View(film);
        }


        [HttpPost]
        public IActionResult BookTicket(int filmId, int showtimeId, List<string> seatNumbers, string paymentMethod)
        {
            var showtime = db.Showtimes.FirstOrDefault(s => s.ShowtimeId == showtimeId);
            if (showtime == null) return NotFound("Showtime không tồn tại.");

            var tickets = new List<Ticket>();
            foreach (var seatNumber in seatNumbers)
            {
                var ticket = new Ticket
                {
                    ShowtimeId = showtime.ShowtimeId,
                    SeatNumber = seatNumber,
                    Price = 45000
                };
                db.Tickets.Add(ticket);
                tickets.Add(ticket);
            }

            // Lưu vé vào database
            db.SaveChanges();

            // Lấy người dùng hiện tại
            var user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name);

            // Tính tổng tiền
            var totalAmount = tickets.Sum(t => t.Price);

            // Tạo hóa đơn cho các vé
            var invoice = new Invoice
            {
                PaymentDate = DateTime.Now,
                PaymentAmount = totalAmount,
                PaymentMethod = paymentMethod, // Để trống phương thức thanh toán cho lần sau
                UserId = user?.UserId
            };
            db.Invoices.Add(invoice);
            db.SaveChanges();

            // Cập nhật InvoiceId cho từng vé
            foreach (var ticket in tickets)
            {
                ticket.InvoiceId = invoice.InvoiceId;
            }
            db.SaveChanges();

            // Chuyển hướng đến trang chi tiết hóa đơn
            return RedirectToAction("InvoiceDetail", new { invoiceId = invoice.InvoiceId });
        }



        




        //[HttpPost]
        //public IActionResult CreateInvoice(int invoiceId, string paymentMethod)
        //{
        //    // Tìm hóa đơn đã tạo
        //    var invoice = db.Invoices.Find(invoiceId);
        //    if (invoice == null) return NotFound("Không tìm thấy hóa đơn.");

        //    // Cập nhật phương thức thanh toán
        //    invoice.PaymentMethod = paymentMethod;
        //    db.SaveChanges();

        //    // Chuyển hướng đến trang chi tiết hóa đơn
        //    return RedirectToAction("InvoiceDetail", new { invoiceId = invoiceId });
        //}


        public IActionResult InvoiceDetail(int invoiceId)
        {
            var invoice = db.Invoices
                .Where(i => i.InvoiceId == invoiceId)
                .Select(i => new
                {
                    i.InvoiceId,
                    i.PaymentDate,
                    i.PaymentAmount,
                    i.PaymentMethod,
                    FilmName = i.Tickets.FirstOrDefault().Showtime.Film.Name,
                    Tickets = i.Tickets.Select(t => new
                    {
                        t.SeatNumber,
                        t.Price,
                        
                    }).ToList(),
                    UserName = i.User.FullName,
                    Gmail = i.User.Email

                })
                .FirstOrDefault();

            if (invoice == null) return NotFound();

            return View(invoice);
        }

    }
}
