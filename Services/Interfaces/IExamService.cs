using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IExamService
    {
        void AddQuestion(TblUserExam exam);
        void UpdateQuestion(TblUserExam exam);
        void DeleteQuestion(int examId);
        List<TblUserExam> GetAlLExams();
        TblUserExam GetExamsById(int examId);
        
    }
}
