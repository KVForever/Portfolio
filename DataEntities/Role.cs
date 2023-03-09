using System;
using System.Collections.Generic;

namespace DataEntities;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
