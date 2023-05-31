using System.ComponentModel.DataAnnotations;

namespace KalPortfolio.Models
{
    public class AddRating
    {
        [Required]
        [RegularExpression("^([1-5])$", ErrorMessage = "This is not a valid rating.")]
        public int Rating { get; set; }

    }
}
