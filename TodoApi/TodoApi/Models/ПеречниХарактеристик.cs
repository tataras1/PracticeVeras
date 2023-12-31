﻿using System;
using System.Collections.Generic;

namespace TodoApi.Models;

public partial class ПеречниХарактеристик
{
    public Guid? ПродукцияId { get; set; }

    public string? Ключ { get; set; }

    public string? Значение { get; set; }

    public virtual Продукция? Продукция { get; set; }
}
