using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserQualificationService
    {
        void AddUserQualification(TbluserQualification userQualification);
        void UpdateUserQualification(TbluserQualification userQualification);
        void DeleteUserQualification(int userQualificationId);
        List<TbluserQualification> GetAllUserQualifications();
        TbluserQualification GetUserQualificationById(int userQualificationId);

        List<TbluserQualification> GetUserQualificationsByQualificationId(int qualificationId);
        void AddUserQualificationToUser(TbluserQualification userQualification, int qualificationId);
    }
}
