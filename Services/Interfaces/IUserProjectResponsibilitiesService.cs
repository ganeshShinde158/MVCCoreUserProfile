using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserProjectResponsibilitiesService
    {
        void AddUserProjectResponsibility(TbluserProjectResponsibility userProjectResponsibility);
        void UpdateUserProjectResponsibility(TbluserProjectResponsibility userProjectResponsibility);
        void DeleteUserProjectResponsibility(int userProjectResponsibilityId);
        List<TbluserProjectResponsibility> GetAllUserProjectResponsibilities();
        TbluserProjectResponsibility GetUserProjectResponsibilityById(int userProjectResponsibilityId);

        List<TbluserProjectResponsibility> GetUserProjectResponsibilitiesByProjectId(int projectId);
        void AddUserProjectResponsibilityToProject(TbluserProjectResponsibility userProjectResponsibility, int projectId);
    }
}
