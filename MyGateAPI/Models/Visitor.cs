using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class Visitor
{
    public int VisitorId { get; set; }

    public DateTimeOffset? InTime { get; set; }

    public DateTimeOffset? OutTime { get; set; }

    public int? FlatNo { get; set; }

    public string? PurposeOfVisit { get; set; }

    public int? UserId { get; set; }

    public string? VehicleNo { get; set; }

    public virtual FlatOwner? FlatNoNavigation { get; set; }

    public virtual UserProfile? User { get; set; }

    public virtual ICollection<VisitorPass> VisitorPasses { get; set; } = new List<VisitorPass>();
}
