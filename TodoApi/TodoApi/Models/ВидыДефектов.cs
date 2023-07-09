﻿using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class ВидыДефектов
{
    public int Id { get; set; }

    public string? Вид { get; set; }

    public virtual ICollection<ТаблицаДефектов> ТаблицаДефектовs { get; set; } = new List<ТаблицаДефектов>();
}
