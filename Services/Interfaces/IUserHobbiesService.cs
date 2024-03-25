using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserHobbiesService
    {
        void AddUserHobby(TbluserHobby userHobby);
        void UpdateUserHobby(TbluserHobby userHobby);
        void DeleteUserHobby(int userHobbyId);
        List<TbluserHobby> GetAllUserHobbies();
        TbluserHobby GetUserHobbyById(int userHobbyId);
    }
}
