using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class CreateMessage
    {
        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,255}$", ErrorMessage = "Invalid First Name.")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,255}$", ErrorMessage = "Invalid Last Name.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,255}$", ErrorMessage = "Invalid Subject.")]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("([a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])){1,255}", ErrorMessage = "Email invalid, make sure your email has all lower case letter.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,2147483647}$", ErrorMessage = "Invalid UserMessage.")]
        public string Message { get; set; }
    }
}
