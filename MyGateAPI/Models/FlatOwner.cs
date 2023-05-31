using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class FlatOwner
{
    public int FlatOwnerId { get; set; }

    public int? FlatNo { get; set; }

    public int? NoOfSeniorCitizen { get; set; }

    public int? NoOfPets { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual UserProfile? User { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public virtual ICollection<VisitorPass> VisitorPasses { get; set; } = new List<VisitorPass>();

    public virtual ICollection<Visitor> Visitors { get; set; } = new List<Visitor>();
}
