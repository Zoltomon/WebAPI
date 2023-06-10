﻿using System;
using System.Collections.Generic;

namespace AutoZolto.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? NameRole { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
