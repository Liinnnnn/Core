using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Invoice
{

    public Invoice() { }
    public int InvoiceId { get; set; }

    public DateTime PaymentDate { get; set; }

    public decimal PaymentAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public int? TicketId { get; set; }

    public int? UserId { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
