using System;
using System.Collections.Generic;

namespace WebAPI.Models;

public partial class Status
{
    public int Id { get; set; }

    public string? NameStatus { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
