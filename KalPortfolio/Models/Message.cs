using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace KalPortfolio.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Please give your first name."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please give your last name."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please give your message a subject."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Please give your Email.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "What would you like to say?"), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string ViewerMessage { get; set; }


    }

    public class MessageDbContext : DbContext
    { 
        public DbSet<Message> Messages { get; set; }
    }

}
