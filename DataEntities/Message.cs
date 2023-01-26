using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataEntities;

public partial class Message
{

    public Guid Id { get; set; }
    [Required(ErrorMessage = "Please give your first name."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string? FirstName { get; set; }
    [Required(ErrorMessage = "Please give your last name."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string? LastName { get; set; }
    [Required(ErrorMessage = "Please give your message a subject."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string Subject { get; set; } = null!;
    [Required(ErrorMessage = "Please give your Email.")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "What would you like to say?"), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string Message1 { get; set; } = null!;
}
