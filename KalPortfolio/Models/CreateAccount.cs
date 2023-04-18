using DataEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class CreateAccount
    {
        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|]){1,255}$", ErrorMessage = "Your username must be at least 1 to 255 characters long.")]
        public string Username { get; set; }

        [Required]
        [RegularExpression("^(?=.*[1-9])(?=.*[a-zA-Z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|])([a-zA-Z0-9!@#$%^&*(),.?\":{}|]){8,255}$", ErrorMessage = "Your password must be at least 8 to 255 characters long. Be sure to put at least one capital, one lower case, and one number in your password.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression("^(?=.*[1-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&*(),.?\":{}|])([a-zA-Z0-9!@#$%^&*(),.?\":{}|]){8,255}$", ErrorMessage = "Your password must be at least 8 to 255 characters long. Be sure to put at least one capital, one lower case, and one number in your password.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression("([a-z0-9!#$%&'*+/=?^_{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])){1,255}", ErrorMessage = "Email invalid, make sure your email has all lower case letter.")]
        public string Email { get; set; }

        
        public List<Role> Roles { get; set; } = new List<Role>();

        
        public List<int> SelectedRoles { get; set; } = new List<int>();

        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,255}$", ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^([a-zA-Z1-9!@#$%^&*(),.?\":{}|\\s]){1,255}$", ErrorMessage = "Invalid Last name")]
        public string LastName { get; set; }   
    }
}
