using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class GenderService : IGenderService
    {
        IRepository<Tblgender> genderrepo;
        public GenderService(IRepository<Tblgender> genderrepo)
        {
            this.genderrepo = genderrepo;
        }

        public void AddGender(Tblgender gender)
        {
            genderrepo.Create(gender);
        }

        public void DeleteGender(int gender_Id)
        {
            genderrepo.Delete(gender_Id);
        }

        public Tblgender GetGenderById(int gender_Id)
        {
          return genderrepo.GetById(gender_Id);
        }

        public List<Tblgender> GetGenders()
        {
            return genderrepo.GetAll();
        }

        public void UpdateGender(Tblgender gender)
        {
            genderrepo.Update(gender);
        }
    }
}
