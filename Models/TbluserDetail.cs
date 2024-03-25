using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserDetail
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public int? GenderId { get; set; }

    public string EmailAddress { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public string? ProfilePhoto { get; set; }

    public virtual Tblgender? Gender { get; set; }

    public virtual ICollection<TblUserExam> TblUserExams { get; set; } = new List<TblUserExam>();

    public virtual ICollection<TbluserExperience> TbluserExperiences { get; set; } = new List<TbluserExperience>();

    public virtual ICollection<TbluserObjective> TbluserObjectives { get; set; } = new List<TbluserObjective>();

    public virtual ICollection<TbluserSkill> TbluserSkills { get; set; } = new List<TbluserSkill>();
}
