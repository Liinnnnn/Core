using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Showtimes
{
    public int ShowtimeId { get; set; }

    public int? FilmID { get; set; }

    public int? CinemaId { get; set; }

    public DateTime? ShowtimeDate { get; set; }

    public string ShowTimeHour { get; set; }

    public int? Capacity { get; set; }

    //public virtual Cinema? Cinema { get; set; }

    public virtual Film? Film { get; set; }
    public Cinema Cinema { get; set; }  // Thêm thuộc tính Cinema
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}