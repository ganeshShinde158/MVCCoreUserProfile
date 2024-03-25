using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserSkillsService
    {
        void AddUserSkill(TbluserSkill userSkill);
        void UpdateUserSkill(TbluserSkill userSkill);
        void DeleteUserSkill(int userSkillId);
        List<TbluserSkill> GetAllUserSkills();
        TbluserSkill GetUserSkillById(int userSkillId);

        List<TbluserSkill> GetUserSkillsByUserId(int userId);
        void AddUserSkillToUser(TbluserSkill userSkill, int userId);
    }
}
