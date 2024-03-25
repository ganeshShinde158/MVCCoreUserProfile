using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class ExamService : IExamService
    {
        IRepository<TblUserExam> _userExamRepository;

        public ExamService(IRepository<TblUserExam> userExamRepository)
        {
            _userExamRepository = userExamRepository;
        }

        public void AddQuestion(TblUserExam exam)
        {
            _userExamRepository.Create(exam);
        }

        public void DeleteQuestion(int examId)
        {
            _userExamRepository.Delete(examId);
        }

        public List<TblUserExam> GetAlLExams()
        {
            return _userExamRepository.GetAll();
        }

        public TblUserExam GetExamsById(int examId)
        {
          return _userExamRepository.GetById(examId);
        }

        public void UpdateQuestion(TblUserExam exam)
        {
            _userExamRepository.Update(exam);
        }
    }
}
