using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class Vehicle
{
    public int VehicleId { get; set; }

    public string? VehicleNo { get; set; }

    public string? Type { get; set; }

    public string? Model { get; set; }

    public int? FlatNo { get; set; }

    public int? RoleId { get; set; }

    public int? UserId { get; set; }

    public virtual FlatOwner? FlatNoNavigation { get; set; }

    public virtual Role? Role { get; set; }

    public virtual UserProfile? User { get; set; }
}
