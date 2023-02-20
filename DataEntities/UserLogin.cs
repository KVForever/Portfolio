using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class UserLogin
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateAdded { get; set; }
}
