using System;
using System.Collections.Generic;

namespace DostavkaFood;

public partial class Order
{
    public int IdOrder { get; set; }

    public int? IdFood { get; set; }

    public int? IdClient { get; set; }

    public int Number { get; set; }

    public float Summa { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Food? IdFoodNavigation { get; set; }
}
