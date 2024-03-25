using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface ITopicContentService
    {
        void AddTopicContent(TblTopicContent topicContent);
        void UpdateTopicContent(TblTopicContent topicContent);
        void DeleteTopicContent(int contentId);
        List<TblTopicContent> GetAllTopicContents();
        TblTopicContent GetTopicContentById(int contentId);
        List<TblTopicContent> GetTopicContentsByTopicId(int topicId);
    }
}
