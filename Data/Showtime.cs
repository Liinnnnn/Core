using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Showtime
{
    public int ShowtimeId { get; set; }

    public int? FilmId { get; set; }

    public int? CinemaId { get; set; }

    public DateTime? Showtime1 { get; set; }

    public int? Capacity { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual Film? Film { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
