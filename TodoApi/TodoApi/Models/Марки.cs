using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Марки
{
    public int Id { get; set; }

    public string? Марка { get; set; }

    public virtual ICollection<Продукция> Продукцияs { get; set; } = new List<Продукция>();
}
