using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Ведомости
{
    public int ВедомостьId { get; set; }

    public int? ТипВедомости { get; set; }

    public DateTime? ДатаВремя { get; set; }

    public string? Ответственные { get; set; }

    public int? МестоФормирования { get; set; }

    public virtual Места? МестоФормированияNavigation { get; set; }

    public virtual ТипыВедомости? ТипВедомостиNavigation { get; set; }
}
