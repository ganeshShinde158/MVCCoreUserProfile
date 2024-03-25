using MVCCoreUserProfile.Models;
using System.Linq.Expressions;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create (TEntity entity);
        void Update (TEntity entity);
        void Delete (int Id);
        List<TEntity> GetAll ();
        TEntity GetById (int Id);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        List<QuestionModel> GetExamQuestions(int topicId, int size);



    }
}
