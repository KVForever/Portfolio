using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class UserLoginModel
    {
        [Required]
        [RegularExpression("^(?=.*[a-zA-Z]).{1,25}$", ErrorMessage = "Your username must be at least 1 to 25 characters long. Be sure to put at least one capital, one lower case, and one number in your password.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[1-9])(?=.*[A-Z])(?=.*[a-z]).{8,25}$", ErrorMessage = "Your password must be at least 8 to 25 characters long. Be sure to put at least one capital, one lower case, and one number in your password.")]
        public string Password { get; set; }


        public string ReturnUrl { get; set; }
    }
}
