using MVCCoreUserProfile.Models;
namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IDesignationService
    {
        void AddDesignation(Tbldesignation designation);
        void UpdateDesignation(Tbldesignation designation);
        void DeleteDesignation(int  designation_Id);
        List<Tbldesignation> GetDesignations();
        Tbldesignation GetDesignationById(int designation_Id);

    }
}
