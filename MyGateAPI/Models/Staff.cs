using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? Shift { get; set; }

    public int? FlatNo { get; set; }

    public int? UserId { get; set; }

    public virtual FlatOwner? FlatNoNavigation { get; set; }

    public virtual UserProfile? User { get; set; }

    public virtual ICollection<VisitorPass> VisitorPasses { get; set; } = new List<VisitorPass>();
}
