using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class Tbldesignation
{
    public int DesignationId { get; set; }

    public string? DesignationName { get; set; }

    public virtual ICollection<TbluserExperience> TbluserExperiences { get; set; } = new List<TbluserExperience>();
}
