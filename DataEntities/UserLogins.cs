using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataEntities;

public partial class UserLogins
{
    [Key]
    public Guid Id { get; set; }

    [Required, RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z]).{8,15})$")]
    public string UserName { get; set; } = null!;
    [Required, RegularExpression(@"^((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$")]
    [PasswordPropertyText]
    public string Password { get; set; } = null!;
}
