using System;
using System.Collections.Generic;

namespace MVCCoreUserProfile.Models;

public partial class TblUserExamQuestion
{
    public int ExamQuestionId { get; set; }

    public int? ExamId { get; set; }

    public int? QuestionId { get; set; }

    public int? SubmitedOptionNumber { get; set; }

    public virtual TblUserExam? Exam { get; set; }

    public virtual TblContentQuestion? Question { get; set; }
}
