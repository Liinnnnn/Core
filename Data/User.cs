using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class User
{
    public User() { }
    public User(string fullName, DateOnly birthDay, string? gender, string phoneNumber, string? avatarImg, string Email, string Password, string Type = "User")
    {
        FullName = fullName;
        BirthDay = birthDay;
        Gender = gender;
        PhoneNumber = phoneNumber;
        AvatarImg = avatarImg;
        this.Type = Type;
        this.Email = Email;
        this.Password = Password;
    }

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
}
