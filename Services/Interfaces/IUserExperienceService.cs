using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserExperienceService
    {
        void AddUserExperience(TbluserExperience userExperience);
        void UpdateUserExperience(TbluserExperience userExperience);
        void DeleteUserExperience(int userExperienceId);
        List<TbluserExperience> GetAllUserExperiences();
        TbluserExperience GetUserExperienceById(int userExperienceId);

        void AddUserExperienceWithDesignation(TbluserExperience userExperience, int userId, int designationId);
        void UpdateUserExperienceWithDesignation(TbluserExperience userExperience, int userId, int designationId);
        List<TbluserExperience> GetUserExperiencesByUserId(int userId);
        List<TbluserExperience> GetUserExperiencesByDesignationId(int designationId);
    }
}
