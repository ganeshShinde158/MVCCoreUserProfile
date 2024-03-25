using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserObjectivesService
    {
        void AddUserObjective(TbluserObjective userObjective);
        void UpdateUserObjective(TbluserObjective userObjective);
        void DeleteUserObjective(int userObjectiveId);
        List<TbluserObjective> GetAllUserObjectives();
        TbluserObjective GetUserObjectiveById(int userObjectiveId);

        List<TbluserObjective> GetUserObjectivesByUserId(int userId);
        void AddUserObjectiveToUser(TbluserObjective userObjective, int userId);
    }
}
