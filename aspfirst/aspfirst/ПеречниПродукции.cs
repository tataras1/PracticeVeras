using System;
using System.Collections.Generic;

namespace aspfirst;

public partial class ПеречниПродукции
{
    public int? Ведомость { get; set; }

    public Guid? Продукция { get; set; }

    public virtual Ведомости? ВедомостьNavigation { get; set; }

    public virtual Продукция? ПродукцияNavigation { get; set; }
}
