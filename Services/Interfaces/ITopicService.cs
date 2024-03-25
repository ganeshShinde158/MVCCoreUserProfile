using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface ITopicService
    {
        void AddTopic(TblTopic topic);
        void UpdateTopic(TblTopic topic);
        void DeleteTopic(int topicId);
        List<TblTopic> GetAllTopics();
        TblTopic GetTopicById(int topicId);
    }
}
