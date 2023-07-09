using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class ТипыВедомости
{
    public int Id { get; set; }

    public string? ТипВедомости { get; set; }

    public virtual ICollection<Ведомости> Ведомостиs { get; set; } = new List<Ведомости>();
}
