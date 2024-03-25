using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IGenderService
    {
        void AddGender(Tblgender gender);
        void UpdateGender(Tblgender gender);
        void DeleteGender(int gender_Id);
        List<Tblgender> GetGenders();
        Tblgender GetGenderById(int gender_Id);
    }
}
