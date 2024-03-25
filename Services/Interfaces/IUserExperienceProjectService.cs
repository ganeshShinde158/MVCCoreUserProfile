using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserExperienceProjectService
    {
        void AddUserExperienceProject(TbluserExperienceProject userExperienceProject);
        void UpdateUserExperienceProject(TbluserExperienceProject userExperienceProject);
        void DeleteUserExperienceProject(int  userExperienceProject_Id);
        List<TbluserExperienceProject> GetAllExperienceProjects();
        TbluserExperienceProject GetUserExperienceProjectById(int userExperienceProject_Id);
        void AddUserExperienceProjectWithExperience(TbluserExperienceProject experienceProject,int experience_id);
        void UpdateUserExperienceProjectWithExperience(TbluserExperienceProject experienceProject, int experience_id);
       List<TbluserExperienceProject> GetAllExperienceProjectsByExperience(int experience_id);

    }
}
