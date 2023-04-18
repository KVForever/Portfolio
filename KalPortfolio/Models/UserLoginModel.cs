using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class UserLoginModel
    {
        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|]){1,255}$", ErrorMessage = "Your username must be at least 1 to 25 characters long. ")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[1-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|])([a-zA-Z\\d!@#$%^&*(),.?\":{}|]){8,255}$", ErrorMessage = "Your password must be at least 8 to 25 characters long. Be sure to put at least one capital, one lower case, and one number in your password.")]
        public string Password { get; set; }

        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|]){1,255}$", ErrorMessage = "Invalid Return Url")]
        public string ReturnUrl { get; set; }
    }
}
