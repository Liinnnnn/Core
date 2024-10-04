using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public DateOnly? BirthDay { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AvatarImg { get; set; }

    public int? AccountId { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public User() { }

    public User(string FullName, DateOnly Birthday, string Gender, string PhoneNumber, string AvatarImg)
    {
        this.FullName = FullName;
        this.PhoneNumber = PhoneNumber;
        this.AvatarImg = AvatarImg;
        this.BirthDay = Birthday;
        this.Gender = Gender;
    }
}
