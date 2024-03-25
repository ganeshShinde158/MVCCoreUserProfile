using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserHobbiesService : IUserHobbiesService
    {
        IRepository<TbluserHobby> userHobbyrepo;
        public UserHobbiesService(IRepository<TbluserHobby> userHobbyrepo)
        {
            this.userHobbyrepo = userHobbyrepo;
        }

        public void AddUserHobby(TbluserHobby userHobby)
        {
            userHobbyrepo.Create(userHobby);
        }

        public void DeleteUserHobby(int userHobbyId)
        {
            userHobbyrepo.Delete(userHobbyId);
        }

        public List<TbluserHobby> GetAllUserHobbies()
        {
            return userHobbyrepo.GetAll();
        }

        public TbluserHobby GetUserHobbyById(int userHobbyId)
        {
            return userHobbyrepo.GetById(userHobbyId);
        }

        public void UpdateUserHobby(TbluserHobby userHobby)
        {
            userHobbyrepo.Update(userHobby);
        }
    }
}
