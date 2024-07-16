using System;
using System.Collections.Generic;

namespace heidischwartz_c969.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int AddressId { get; set; }

    public bool Active { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public string LastUpdateBy { get; set; } = null!;

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; } = new List<Appointment>();
}
