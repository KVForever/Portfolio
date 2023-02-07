using System.ComponentModel.DataAnnotations;

namespace DataEntities;

public partial class UserMessage
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "This is a required feild")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "This is a required feild")]
    public string? LastName { get; set; }

    
    public string? Email { get; set; }

    
    public string? Subject { get; set; }

    
    public string Message { get; set; } = null!;
}
//RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")