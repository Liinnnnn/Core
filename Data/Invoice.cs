using projekt1.Data;

public partial class Invoice
{
    public int InvoiceId { get; set; }
    public DateTime PaymentDate { get; set; }
    public decimal PaymentAmount { get; set; }
    public string? PaymentMethod { get; set; }
    public int? UserId { get; set; }

    public virtual User? User { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>(); // Tập hợp các vé thuộc hóa đơn
}
