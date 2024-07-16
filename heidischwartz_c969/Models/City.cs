using System;
using System.Collections.Generic;

namespace heidischwartz_c969.Models;

public partial class City
{
    public int CityId { get; set; }

    public string City1 { get; set; } = null!;

    public int CountryId { get; set; }

    public DateTime CreateDate { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime LastUpdate { get; set; }

    public string LastUpdateBy { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;
}
