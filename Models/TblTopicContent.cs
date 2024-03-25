using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TblTopicContent
{
    public int ContentId { get; set; }

    public string? ContentName { get; set; }

    public int? TopicId { get; set; }

    public virtual ICollection<TblContentQuestion> TblContentQuestions { get; set; } = new List<TblContentQuestion>();

    public virtual TblTopic? Topic { get; set; }
}
