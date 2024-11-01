using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace projekt1.Data;

public partial class Film
{
    public int FilmId { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string Name { get; set; } 
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string? Language { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string? Director { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string? Description { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public int? Duration { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public int? Year { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string? FilmImg { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string? BannerImg { get; set; }
    [Required(ErrorMessage = "Vui lòng nhập trường nhày")]

    public string suatChieu {  get; set; }

    

    public virtual ICollection<Showtimes> Showtimes { get; set; } = new List<Showtimes>();
}
