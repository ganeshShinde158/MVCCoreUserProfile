using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class DesignationService : IDesignationService
    {
        IRepository<Tbldesignation> designationrepo;
        public DesignationService(IRepository<Tbldesignation> designationrepo)
        {
            this.designationrepo = designationrepo;
        }

        public void AddDesignation(Tbldesignation designation)
        {
            designationrepo.Create(designation);
        }

        public void DeleteDesignation(int designation_Id)
        {
            designationrepo.Delete(designation_Id);
            
        }

        public Tbldesignation GetDesignationById(int designation_Id)
        {
            return designationrepo.GetById(designation_Id);
        }

        public List<Tbldesignation> GetDesignations()
        {
            return designationrepo.GetAll();
        }

        public void UpdateDesignation(Tbldesignation designation)
        {
            designationrepo.Update(designation);
        }
    }
}
