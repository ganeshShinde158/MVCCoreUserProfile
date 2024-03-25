using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserExperience
{
    public int ExperienceId { get; set; }

    public int? UserId { get; set; }

    public string? CompanyName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? DesignationId { get; set; }

    public virtual Tbldesignation? Designation { get; set; }

    public virtual ICollection<TbluserExperienceProject> TbluserExperienceProjects { get; set; } = new List<TbluserExperienceProject>();

    public virtual TbluserDetail? User { get; set; }
}
