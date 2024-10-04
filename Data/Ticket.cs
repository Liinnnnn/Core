using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string SeatNumber { get; set; } = null!;

    public decimal Price { get; set; }

    public int? ShowtimeId { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Showtime? Showtime { get; set; }
}
