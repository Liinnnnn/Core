using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Film
{
    public int FilmId { get; set; }

    public string Name { get; set; } = null!;

    public string? Language { get; set; }

    public string? Director { get; set; }

    public string? Description { get; set; }

    public int? Duration { get; set; }

    public int? Year { get; set; }

    public string? FilmImg { get; set; }

    public string? BannerImg { get; set; }

    public string Filter {  get; set; }

    public int Status { get; set; }

    public virtual ICollection<Showtime> Showtimes { get; set; } = new List<Showtime>();
}
