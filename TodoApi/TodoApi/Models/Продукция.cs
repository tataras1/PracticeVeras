using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Продукция
{
    public Guid Id { get; set; }

    public string? Клеймо { get; set; }

    public int? Профиль { get; set; }

    public int? МаркаСтали { get; set; }

    public virtual Марки? МаркаСталиNavigation { get; set; }

    public virtual Профили? ПрофильNavigation { get; set; }

    public virtual ICollection<ТаблицаДефектов> ТаблицаДефектовs { get; set; } = new List<ТаблицаДефектов>();
}
