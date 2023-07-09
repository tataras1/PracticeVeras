using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class ТаблицаДефектов
{
    public int ДефектId { get; set; }

    public int? Вид { get; set; }

    public decimal? ДлинаДефекта { get; set; }

    public Guid? ПродукцияId { get; set; }

    public virtual ВидыДефектов? ВидNavigation { get; set; }

    public virtual Продукция? Продукция { get; set; }
}
