using projekt1.Data;

public partial class Ticket
{
    public int TicketId { get; set; }
    public string SeatNumber { get; set; } = null!;
    public decimal Price { get; set; }
    public int? ShowtimeId { get; set; }
    public int? InvoiceId { get; set; } // Khóa ngoại đến Invoice

    public virtual Showtimes? Showtime { get; set; }
    public virtual Invoice? Invoice { get; set; } // Mỗi vé thuộc về một hóa đơn
}
