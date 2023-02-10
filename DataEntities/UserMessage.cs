using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class UserMessage
{
    
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public string Subject { get; set; } = null!;

    public string Message { get; set; } = null!;
}
