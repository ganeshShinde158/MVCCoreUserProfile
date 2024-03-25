using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserProjectResponsibility
{
    public int ResponsibilityId { get; set; }

    public int? ProjectId { get; set; }

    public string? Responsibility { get; set; }

    public virtual TbluserExperienceProject? Project { get; set; }
}
