using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserSkillsService : IUserSkillsService
    {
        Repository<TbluserSkill> userSkillrepo;
        public UserSkillsService(Repository<TbluserSkill> userSkillrepo)
        {
            this.userSkillrepo = userSkillrepo;
        }

        public void AddUserSkill(TbluserSkill userSkill)
        {
            userSkillrepo.Create(userSkill);
        }

        public void AddUserSkillToUser(TbluserSkill userSkill, int userId)
        {
            userSkill.UserId = userId;
            userSkillrepo.Create(userSkill);
        }

        public void DeleteUserSkill(int userSkillId)
        {
            userSkillrepo.Delete(userSkillId);
        }

        public List<TbluserSkill> GetAllUserSkills()
        {
           return userSkillrepo.GetAll();
        }

        public TbluserSkill GetUserSkillById(int userSkillId)
        {
           return userSkillrepo.GetById(userSkillId);
        }

        public List<TbluserSkill> GetUserSkillsByUserId(int userId)
        {
            return userSkillrepo.GetAll().Where(skill => skill.UserId == userId).ToList();

        }

        public void UpdateUserSkill(TbluserSkill userSkill)
        {
            userSkillrepo.Update(userSkill);
        }
    }
}
