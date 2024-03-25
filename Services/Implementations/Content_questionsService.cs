using Microsoft.EntityFrameworkCore;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class Content_questionsService:IContent_questionsService
    {
        IRepository<TblContentQuestion> contentQuestionrepo;
        public Content_questionsService(IRepository<TblContentQuestion> contentQuestionrepo)
        {
            this.contentQuestionrepo = contentQuestionrepo;
        }

        public void AddQuestion(TblContentQuestion question)
        {
            contentQuestionrepo.Create(question);
        }

        public void DeleteQuestion(int questionId)
        {
            contentQuestionrepo.Delete(questionId);
        }

        public List<TblContentQuestion> GetAllQuestions()
        {
            return contentQuestionrepo.GetAll();
        }

        public TblContentQuestion GetQuestionById(int questionId)
        {
            return contentQuestionrepo.GetById(questionId);
        }

        public List<TblContentQuestion> GetQuestionsByContentId(int contentId)
        {
            return contentQuestionrepo.GetAll().Where(q => q.ContentId == contentId).ToList();

        }

        public void UpdateQuestion(TblContentQuestion question)
        {
            contentQuestionrepo.Update(question);
        }
    }
}
