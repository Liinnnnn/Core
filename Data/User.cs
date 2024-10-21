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

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public User() { }

    public User(string FullName, DateOnly Birthday, string Gender, string PhoneNumber, string AvatarImg, string Email, string Password, string TypeAccount)
    {
        this.FullName = FullName;
        this.PhoneNumber = PhoneNumber;
        this.AvatarImg = AvatarImg;
        this.BirthDay = Birthday;
        this.Gender = Gender;
        this.Email = Email;
        this.Password = Password;
        this.Type = TypeAccount;
    }
}
