using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class Users
{
    public Guid Id { get; set; }

    public string? Email { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }
}
