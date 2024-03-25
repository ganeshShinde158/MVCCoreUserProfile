using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserProjectResponsibilitiesService : IUserProjectResponsibilitiesService
    {
        IRepository<TbluserProjectResponsibility> userProjectResponsibilityrepo;
        public void AddUserProjectResponsibility(TbluserProjectResponsibility userProjectResponsibility)
        {
            userProjectResponsibilityrepo.Create(userProjectResponsibility);
        }

        public void AddUserProjectResponsibilityToProject(TbluserProjectResponsibility userProjectResponsibility, int projectId)
        {
            userProjectResponsibility.ProjectId = projectId;
            userProjectResponsibilityrepo.Create(userProjectResponsibility);
        }

        public void DeleteUserProjectResponsibility(int userProjectResponsibilityId)
        {
            userProjectResponsibilityrepo.Delete(userProjectResponsibilityId);
        }

        public List<TbluserProjectResponsibility> GetAllUserProjectResponsibilities()
        {
            return userProjectResponsibilityrepo.GetAll();
        }

        public List<TbluserProjectResponsibility> GetUserProjectResponsibilitiesByProjectId(int projectId)
        {
            return userProjectResponsibilityrepo.GetAll().Where(resp => resp.ProjectId == projectId).ToList();
        }

        public TbluserProjectResponsibility GetUserProjectResponsibilityById(int userProjectResponsibilityId)
        {
           return userProjectResponsibilityrepo.GetById(userProjectResponsibilityId);
        }

        public void UpdateUserProjectResponsibility(TbluserProjectResponsibility userProjectResponsibility)
        {
            userProjectResponsibilityrepo.Update(userProjectResponsibility);
        }
    }
}
