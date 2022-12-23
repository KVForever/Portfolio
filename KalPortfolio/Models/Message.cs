using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class Message
    {
        [Required(ErrorMessage = "Please give your name."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please give your message a subject."), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please give your Email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "What would you like to say?"), RegularExpression(@"^[A-Z]+[a-zA-Z'\s/]*$")]
        public string ViewerMessage { get; set; }


    }
}
