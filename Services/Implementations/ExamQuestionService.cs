using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class ExamQuestionService : IExamQuestionService
    {
        IRepository<TblUserExamQuestion> examquestionrepo;

        public ExamQuestionService(IRepository<TblUserExamQuestion> examquestionrepo)
        {
            this.examquestionrepo = examquestionrepo;
        }

        public void AddExamQuestion(TblUserExamQuestion question)
        {
            examquestionrepo.Create(question);
        }

        public void AddQuestion(TblUserExamQuestion question)
        {
            examquestionrepo.Create(question);
        }

        public void DeleteExamQuestion(int questionId)
        {
            examquestionrepo.Delete(questionId);
        }

        public List<TblUserExamQuestion> GetAllExamQuestions()
        {
            return examquestionrepo.GetAll();
        }

        public TblUserExamQuestion GetExamQuestionById(int questionId)
        {
            return examquestionrepo.GetById(questionId);
        }

        

        public void UpdateExamQuestion(TblUserExamQuestion question)
        {
            examquestionrepo.Update(question);
        }
    }
}
