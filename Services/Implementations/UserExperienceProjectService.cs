using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserExperienceProjectService : IUserExperienceProjectService
    {
        IRepository<TbluserExperienceProject> userExperienceProjectrepo;

        public UserExperienceProjectService(IRepository<TbluserExperienceProject> userExperienceProjectrepo)
        {
            this.userExperienceProjectrepo = userExperienceProjectrepo;
        }

        public void AddUserExperienceProject(TbluserExperienceProject userExperienceProject)
        {
            userExperienceProjectrepo.Create(userExperienceProject);
        }

        public void AddUserExperienceProjectWithExperience(TbluserExperienceProject experienceProject, int experience_id)
        {
            experienceProject.ExperienceId = experience_id;
            userExperienceProjectrepo.Create(experienceProject);
        }

        public void DeleteUserExperienceProject(int userExperienceProject_Id)
        {
            userExperienceProjectrepo.Delete(userExperienceProject_Id);
        }

        public List<TbluserExperienceProject> GetAllExperienceProjects()
        {
            return userExperienceProjectrepo.GetAll();
        }

        public List<TbluserExperienceProject> GetAllExperienceProjectsByExperience(int experience_id)
        {
            return userExperienceProjectrepo.GetAll().Where(project => project.ExperienceId == experience_id).ToList();
        }

        public TbluserExperienceProject GetUserExperienceProjectById(int userExperienceProject_Id)
        {
           return userExperienceProjectrepo.GetById(userExperienceProject_Id);
        }

        public void UpdateUserExperienceProject(TbluserExperienceProject userExperienceProject)
        {
            userExperienceProjectrepo.Update(userExperienceProject);
        }

        public void UpdateUserExperienceProjectWithExperience(TbluserExperienceProject experienceProject, int experience_id)
        {
            experienceProject.ExperienceId = experience_id;
            userExperienceProjectrepo.Update(experienceProject);
        }
    }
}
