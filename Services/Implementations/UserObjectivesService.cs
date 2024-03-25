using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserObjectivesService : IUserObjectivesService
    {
        IRepository<TbluserObjective> userObjectiverepo;
        public UserObjectivesService(IRepository<TbluserObjective> userObjectiverepo)
        {
            this.userObjectiverepo = userObjectiverepo;
        }

        public void AddUserObjective(TbluserObjective userObjective)
        {
            userObjectiverepo.Create(userObjective);
        }

        public void AddUserObjectiveToUser(TbluserObjective userObjective, int userId)
        {
            userObjective.UserId = userId;
            userObjectiverepo.Create(userObjective);
        }

        public void DeleteUserObjective(int userObjectiveId)
        {
            userObjectiverepo.Delete(userObjectiveId);
        }

        public List<TbluserObjective> GetAllUserObjectives()
        {
            return userObjectiverepo.GetAll();
        }

        public TbluserObjective GetUserObjectiveById(int userObjectiveId)
        {
            return userObjectiverepo.GetById(userObjectiveId);


        }

        public List<TbluserObjective> GetUserObjectivesByUserId(int userId)
        {
            return userObjectiverepo.GetAll().Where(obj => obj.UserId == userId).ToList();

        }

        public void UpdateUserObjective(TbluserObjective userObjective)
        {
            userObjectiverepo.Update(userObjective);
        }
    }
}
