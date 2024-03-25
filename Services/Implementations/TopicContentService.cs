using Microsoft.EntityFrameworkCore;
using MimeKit;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;
using System.Linq;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class TopicContentService:ITopicContentService
    {
        IRepository<TblTopicContent> topiccontentrepo;

        public TopicContentService(IRepository<TblTopicContent> topiccontentrepo)
        {
            this.topiccontentrepo = topiccontentrepo;
        }

        public void AddTopicContent(TblTopicContent topicContent)
        {
            topiccontentrepo.Create(topicContent);
        }

        public void DeleteTopicContent(int contentId)
        {
            topiccontentrepo.Delete(contentId);
        }

        public List<TblTopicContent> GetAllTopicContents()
        {
            return topiccontentrepo.GetAll();

        }

        public TblTopicContent GetTopicContentById(int contentId)
        {
            return topiccontentrepo.GetById(contentId);
        }

        public List<TblTopicContent> GetTopicContentsByTopicId(int topicId)
        {
            return topiccontentrepo.GetAll().Where(tc => tc.TopicId == topicId).ToList();
        }

        public void UpdateTopicContent(TblTopicContent topicContent)
        {
            topiccontentrepo.Update(topicContent);


        }
    }
}
