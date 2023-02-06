using System.ComponentModel.DataAnnotations;

namespace DataEntities;

public partial class UserMessage
{
    public Guid Id { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string? FirstName { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string? LastName { get; set; }

    
    public string? Email { get; set; }

    [RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
    public string? Subject { get; set; }

    [Required(ErrorMessage = "Please fill out this feild in order to submit this form.")]
    public string Message { get; set; } = null!;
}
