using System;
using System.Collections.Generic;

namespace DostavkaFood;

public partial class Client
{
    public int IdClient { get; set; }

    public string Fio { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
