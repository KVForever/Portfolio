using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class UserLoginModel
    {
        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|]){1,255}$", ErrorMessage = "Your username is incorrect")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[1-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|])([a-zA-Z\\d!@#$%^&*(),.?\":{}|]){8,255}$", ErrorMessage = "Your password is incorrect")]
        public string Password { get; set; }

        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|]){1,255}$", ErrorMessage = "Invalid Return Url")]
        public string ReturnUrl { get; set; }
    }
}
