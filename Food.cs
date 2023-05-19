using System;
using System.Collections.Generic;

namespace DostavkaFood;

public partial class Food
{
    public int IdFood { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public float Price { get; set; }

    public string Note { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
