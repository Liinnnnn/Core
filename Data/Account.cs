using System;
using System.Collections.Generic;

namespace projekt1.Data;

public partial class Account
{
    public int AccountId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Type { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public Account() { }

    public Account(string Email, string Password, string TypeAccount)
    {
        this.Email = Email;
        this.Password = Password;
        this.Type = TypeAccount;
    }
}
