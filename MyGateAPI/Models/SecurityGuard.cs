using System;
using System.Collections.Generic;

namespace MyGateAPI.Models;

public partial class SecurityGuard
{
    public int SecurityGuardId { get; set; }

    public string? Shift { get; set; }

    public string? Address { get; set; }

    public int? UserId { get; set; }

    public virtual UserProfile? User { get; set; }
}
