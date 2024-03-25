using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IContent_questionsService
    {
        void AddQuestion(TblContentQuestion question);
        void UpdateQuestion(TblContentQuestion question);
        void DeleteQuestion(int questionId);
        List<TblContentQuestion> GetAllQuestions();
        TblContentQuestion GetQuestionById(int questionId);
        List<TblContentQuestion> GetQuestionsByContentId(int contentId);
    }
}
