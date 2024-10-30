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
            var showtimes = db.Showtimes.Where(s => s.FilmId == filmId).ToList();
            ViewBag.Showtimes = showtimes;
            // Trả về view đặt vé kèm theo thông tin của phim
            return View(film);
        }
        [HttpPost]
        public IActionResult BookTicket(int filmId, Ticket ticket)
        {
            var showtime = db.Showtimes.FirstOrDefault(s => s.FilmId == filmId);
            if (showtime == null) return NotFound("Showtime không tồn tại cho phim này.");
            ticket.ShowtimeId = showtime.ShowtimeId;
            ticket.Price = 40000;
            db.Tickets.Add(ticket);
            db.SaveChanges();
            // Chuyển hướng đến hóa đơn sau khi đặt vé thành công
            return RedirectToAction("Invoice", new { ticketId = ticket.TicketId });
        }
        public IActionResult Invoice(int ticketId)
        {
            var ticket = db.Tickets
                .Where(t => t.TicketId == ticketId)
                .Select(t => new
                {
                    t.TicketId,
                    t.SeatNumber,
                    t.Price,
                    t.Showtime.Film.Name,
                    t.Showtime.Showtime1,
                    t.Showtime.Cinema.CinemaName,
                    Gmail = User.Identity.Name // Lấy tên người dùng
                })
                .FirstOrDefault();
            if (ticket == null) return NotFound();
            ViewBag.TicketId = ticketId; // Truyền TicketId để lưu Invoice
            return View(ticket);
        }
        [HttpPost]
        public IActionResult CreateInvoice(int ticketId, string paymentMethod)
        {
            // Tạo hóa đơn mới
            var ticket = db.Tickets.Find(ticketId);
            if (ticket == null) return NotFound();
            var user = db.Users.FirstOrDefault(u => u.Email == User.Identity.Name); // Lấy thông tin người dùng
            var invoice = new Invoice
            {
                PaymentDate = DateTime.Now,
                PaymentAmount = ticket.Price,
                PaymentMethod = paymentMethod,
                TicketId = ticketId,
                UserId = user?.UserId // Lưu UserId vào hóa đơn
            };
            // Lưu hóa đơn vào cơ sở dữ liệu
            db.Invoices.Add(invoice);
            db.SaveChanges();
            // Chuyển hướng đến trang hóa đơn đã tạo
            return RedirectToAction("InvoiceDetail", new { invoiceId = invoice.InvoiceId });
        }
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
                    TicketId = i.Ticket.TicketId,
                    SeatNumber = i.Ticket.SeatNumber,
                    FilmName = i.Ticket.Showtime.Film.Name,
                    UserName = i.User.FullName, // Lấy tên người dùng từ hóa đơn
                    Gmail = i.User.Email
                })
                .FirstOrDefault();
            if (invoice == null) return NotFound();
            return View(invoice);
        }
    }
}