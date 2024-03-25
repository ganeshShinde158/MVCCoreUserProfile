using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IQualificationService
    {
        void AddQualification(Tblqualification qualification);
        void UpdateQualification(Tblqualification qualification);
        void DeleteQualification(int qualification_Id);
        List<Tblqualification> GetQualifications();
        Tblqualification GetQualificationById(int qualification_Id);
    }
}
