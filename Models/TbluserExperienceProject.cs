using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserExperienceProject
{
    public int ProjectId { get; set; }

    public int? ExperienceId { get; set; }

    public string? ClientName { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Project { get; set; }

    public string? ProjectDescription { get; set; }

    public virtual TbluserExperience? Experience { get; set; }

    public virtual ICollection<TbluserProjectResponsibility> TbluserProjectResponsibilities { get; set; } = new List<TbluserProjectResponsibility>();
}
