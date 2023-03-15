using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class UserMessage
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Subject { get; set; }

    public string Message { get; set; } = null!;
}
