using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TbluserQualification
{
    public int UserQualificationId { get; set; }

    public int? QualificationId { get; set; }

    public string? University { get; set; }

    public int? PassingYear { get; set; }

    public string? Medium { get; set; }

    public double? Percentage { get; set; }

    public virtual Tblqualification? Qualification { get; set; }
}
