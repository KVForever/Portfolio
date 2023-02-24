using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntities;

public partial class UserMessages
{
    [Key]
    public Guid Id { get; set; }

    [Required, RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$")]
    public string FirstName { get; set; } = null!;

    [Required, RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$")]
    public string LastName { get; set; } = null!;

    [EmailAddress]
    public string? Email { get; set; }

    [Required, RegularExpression(@"^[a-zA-Z''-'\s]{2,40}$")]
    public string Subject { get; set; } = null!;

    [Required, RegularExpression(@"^[a-zA-Z''-'\S]{2,600}$")]
    public string Message { get; set; } = null!;
}
