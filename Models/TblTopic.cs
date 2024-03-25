using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TblTopic
{
    public int TopicId { get; set; }

    public string? TopicName { get; set; }

    public virtual ICollection<TblTopicContent> TblTopicContents { get; set; } = new List<TblTopicContent>();

    public virtual ICollection<TblUserExam> TblUserExams { get; set; } = new List<TblUserExam>();
}
