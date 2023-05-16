using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace KalPortfolio.Models
{
    public class AddRating
    {
        //[Required]
        //[RegularExpression("^([1-5])$", ErrorMessage = "This is not a valid rating.")]
        public int Rating { get; set; }

        
    }
}
