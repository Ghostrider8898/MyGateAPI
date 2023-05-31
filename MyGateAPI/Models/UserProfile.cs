using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class UserProfile
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Contact { get; set; }

    public string? AadharCardNo { get; set; }

    public string? Gender { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<FlatOwner> FlatOwners { get; set; } = new List<FlatOwner>();

    public virtual Role? Role { get; set; }

    public virtual ICollection<SecurityGuard> SecurityGuards { get; set; } = new List<SecurityGuard>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
