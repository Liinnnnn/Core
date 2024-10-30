using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Cinema
{
    public int CinemaId { get; set; }

    public string CinemaName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Showtimes> Showtimes { get; set; } = new List<Showtimes>();
}
