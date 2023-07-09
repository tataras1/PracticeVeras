using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Профили
{
    public int Id { get; set; }

    public string? Профиль { get; set; }

    public virtual ICollection<Продукция> Продукцияs { get; set; } = new List<Продукция>();
}
