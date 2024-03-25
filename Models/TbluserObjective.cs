using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserObjective
{
    public int ObjectiveId { get; set; }

    public int? UserId { get; set; }

    public string? Objective { get; set; }

    public virtual TbluserDetail? User { get; set; }
}
