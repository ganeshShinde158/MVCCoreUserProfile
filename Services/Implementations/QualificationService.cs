using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class QualificationService : IQualificationService
    {
        IRepository<Tblqualification> qualificationrepo;
        public QualificationService(IRepository<Tblqualification> qualificationrepo)
        {
            this.qualificationrepo = qualificationrepo;
        }

        public void AddQualification(Tblqualification qualification)
        {
            qualificationrepo.Create(qualification);
        }

        public void DeleteQualification(int qualification_Id)
        {
            qualificationrepo.Delete(qualification_Id);
        }

        public Tblqualification GetQualificationById(int qualification_Id)
        {
            return qualificationrepo.GetById(qualification_Id);
        }

        public List<Tblqualification> GetQualifications()
        {
            return qualificationrepo.GetAll();


        }

        public void UpdateQualification(Tblqualification qualification)
        {
            qualificationrepo.Update(qualification);
        }
    }
}
