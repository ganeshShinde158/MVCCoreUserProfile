using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserExperienceService : IUserExperienceService
    {
        IRepository<TbluserExperience> userExperiencerepo;
        public UserExperienceService(IRepository<TbluserExperience> userExperiencerepo)
        {
            this.userExperiencerepo = userExperiencerepo;
        }

        public void AddUserExperience(TbluserExperience userExperience)
        {
            userExperiencerepo.Create(userExperience);
        }

        public void AddUserExperienceWithDesignation(TbluserExperience userExperience, int userId, int designationId)
        {
            userExperience.UserId = userId;
            userExperience.DesignationId = designationId;
            userExperiencerepo.Create(userExperience);
        }

        public void DeleteUserExperience(int userExperienceId)
        {
            userExperiencerepo.Delete(userExperienceId);
        }

        public List<TbluserExperience> GetAllUserExperiences()
        {
            return userExperiencerepo.GetAll();
        }

        public TbluserExperience GetUserExperienceById(int userExperienceId)
        {
           return userExperiencerepo.GetById(userExperienceId);
        }

        public List<TbluserExperience> GetUserExperiencesByDesignationId(int designationId)
        {
            return userExperiencerepo.GetAll().Where(exp => exp.DesignationId == designationId).ToList();
        }

        public List<TbluserExperience> GetUserExperiencesByUserId(int userId)
        {
            return userExperiencerepo.GetAll().Where(exp => exp.UserId == userId).ToList();

        }

        public void UpdateUserExperience(TbluserExperience userExperience)
        {
            userExperiencerepo.Update(userExperience);
        }

        public void UpdateUserExperienceWithDesignation(TbluserExperience userExperience, int userId, int designationId)
        {
            userExperience.UserId = userId;
            userExperience.DesignationId = designationId;
            userExperiencerepo.Update(userExperience);
        }
    }
}
