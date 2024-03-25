using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;
using System.Linq.Expressions;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        UserProfileDbContext _dbcontext;
        public Repository(UserProfileDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
            _dbcontext.SaveChanges();
        }

        public void Delete(int Id)
        {
            TEntity entity = _dbcontext.Set<TEntity>().Find(Id);
            _dbcontext.Set<TEntity>().Remove(entity);
            _dbcontext.SaveChanges(); 
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbcontext.Set<TEntity>().FirstOrDefault(predicate);

        }

        public List<TEntity> GetAll()
        {
            return _dbcontext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return _dbcontext.Set<TEntity>().Find(Id);
        }

        public List<QuestionModel> GetExamQuestions(int topicId, int size)
        {
            var query = from t in _dbcontext.TblTopics.ToList()
                        join c in _dbcontext.TblTopicContents.ToList() on t.TopicId equals c.TopicId
                        join q in _dbcontext.TblContentQuestions.ToList() on c.ContentId equals q.ContentId
                        where t.TopicId.Equals(topicId)
                        select new QuestionModel
                        {
                            topic_id = t.TopicId,
                            topic_name = t.TopicName,
                            content_id = c.ContentId,
                            content_name = c.ContentName,
                            question_id = q.QuestionId,
                            question = q.Question,
                            option1 = q.Option1,
                            option2 = q.Option2,
                            option3 = q.Option3,
                            option4 = q.Option4,
                            correct_option_number = (int)q.CorrectOptionNumber
                        };

            List<QuestionModel> questions = query.Take(size).ToList();
            return questions;
        }

        public void Update(TEntity entity)
        {
            _dbcontext.Entry<TEntity>(entity).State=Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbcontext.SaveChanges();
        }
    }
}
