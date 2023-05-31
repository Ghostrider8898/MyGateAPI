using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class VisitorPass
{
    public int PassId { get; set; }

    public int? FlatNo { get; set; }

    public int? StaffId { get; set; }

    public int? VisitorId { get; set; }

    public string? VehicleNo { get; set; }

    public DateTimeOffset? ExpiryDate { get; set; }

    public virtual FlatOwner? FlatNoNavigation { get; set; }

    public virtual Staff? Staff { get; set; }

    public virtual Visitor? Visitor { get; set; }
}
