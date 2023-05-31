using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class UserMessage
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Importance { get; set; }

    public string Message { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public bool IsDeleted { get; set; }
}
