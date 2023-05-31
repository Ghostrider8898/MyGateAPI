using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
