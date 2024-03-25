using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserQualificationService : IUserQualificationService
    {
        IRepository<TbluserQualification> userQualificationrepo;
        public UserQualificationService(IRepository<TbluserQualification> userQualificationrepo)
        {
            this.userQualificationrepo = userQualificationrepo;
        }

        public void AddUserQualification(TbluserQualification userQualification)
        {
            userQualificationrepo.Create(userQualification);

        }

        public void AddUserQualificationToUser(TbluserQualification userQualification, int qualificationId)
        {
            userQualification.QualificationId = qualificationId;
            userQualificationrepo.Create(userQualification);
        }

        public void DeleteUserQualification(int userQualificationId)
        {
            userQualificationrepo.Delete(userQualificationId);
        }

        public List<TbluserQualification> GetAllUserQualifications()
        {
            return userQualificationrepo.GetAll();
        }

        public TbluserQualification GetUserQualificationById(int userQualificationId)
        {
            return userQualificationrepo.GetById(userQualificationId);
        }

        public List<TbluserQualification> GetUserQualificationsByQualificationId(int qualificationId)
        {
            return userQualificationrepo.GetAll().Where(qual => qual.QualificationId == qualificationId).ToList();
        }

        public void UpdateUserQualification(TbluserQualification userQualification)
        {
            userQualificationrepo.Update(userQualification);
        }
    }
}
