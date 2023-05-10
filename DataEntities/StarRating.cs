using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class StarRating
{
    public int Id { get; set; }

    public int Rating { get; set; }

    public DateTime DateRated { get; set; }
}
