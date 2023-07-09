using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class Места
{
    public int Id { get; set; }

    public string? Место { get; set; }

    public virtual ICollection<Ведомости> Ведомостиs { get; set; } = new List<Ведомости>();
}
