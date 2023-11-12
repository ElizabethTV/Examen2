﻿using System;
using System.Collections.Generic;

namespace exam2.Models;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book>? Books { get; set; } = new List<Book>();
}