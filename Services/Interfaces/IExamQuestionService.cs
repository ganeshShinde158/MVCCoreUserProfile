using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IExamQuestionService
    {
        void AddExamQuestion(TblUserExamQuestion question);
        void DeleteExamQuestion(int questionId);
        List<TblUserExamQuestion> GetAllExamQuestions();
        TblUserExamQuestion GetExamQuestionById(int questionId);
        void UpdateExamQuestion(TblUserExamQuestion question);

    }
}
