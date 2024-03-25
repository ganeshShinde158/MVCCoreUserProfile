using Microsoft.EntityFrameworkCore;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class TopicService:ITopicService
    {
        IRepository<TblTopic> topicrepo;
        public TopicService(IRepository<TblTopic> topicrepo)
        {
            this.topicrepo = topicrepo;
        }



        public void AddTopic(TblTopic topic)
        {
            topicrepo.Create(topic);

        }

        public void DeleteTopic(int topicId)
        {
            topicrepo.Delete(topicId);
        }

        public List<TblTopic> GetAllTopics()
        {
            return topicrepo.GetAll();
        }

        public TblTopic GetTopicById(int topicId)
        {
            return topicrepo.GetById(topicId);
        }

        public void UpdateTopic(TblTopic topic)
        {
            topicrepo.Update(topic);
        }
    }
}
