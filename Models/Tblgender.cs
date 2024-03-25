using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class Tblgender
{
    public int GenderId { get; set; }

    public string? Gender { get; set; }

    public virtual ICollection<TbluserDetail> TbluserDetails { get; set; } = new List<TbluserDetail>();
}
