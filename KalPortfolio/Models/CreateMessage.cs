using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    //TODO: validate the input
    public class CreateMessage
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Subject { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Message { get; set; }
    }
}
