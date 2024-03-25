using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class UserDetailsService : IUserDetailsService
    {
        IRepository<TbluserDetail> userDetailrepo;
        public UserDetailsService(IRepository<TbluserDetail> userDetailrepo)
        {
            this.userDetailrepo = userDetailrepo;
        }

        public void AddUserDetails(TbluserDetail userDetails)
        {
            userDetailrepo.Create(userDetails);


        }

        public void AddUserDetailWithGender(TbluserDetail userDetails, int genderId)
        {
            userDetails.GenderId = genderId;
            userDetailrepo.Create(userDetails);
        }

        

        public void DeleteUserDetails(int userDetails_Id)
        {
            userDetailrepo.Delete(userDetails_Id);
        }

        public List<TbluserDetail> GetUserDetails()
        {
            return userDetailrepo.GetAll();
        }

        public List<TbluserDetail> GetUserDetailsByGender(int genderId)
        {
            return userDetailrepo.GetAll().Where(u => u.GenderId == genderId).ToList();

        }

        public TbluserDetail GetUserDetailsById(int userDetailsId)
        {
           return userDetailrepo.GetById(userDetailsId);
        }

        public void UpdateUserDetails(TbluserDetail userDetails)
        {
            userDetailrepo.Update(userDetails);
        }

        public void UpdateUserDetailWithGender(TbluserDetail userDetails, int genderId)
        {
            userDetails.GenderId = genderId;
            userDetailrepo.Update(userDetails);
        }

        public bool ValidateCredentials(string empcode, string password, out TbluserDetail employee)
        {

            employee = userDetailrepo.FirstOrDefault(x => x.UserName.Equals(empcode) && x.Password.Equals(password));
            return employee != null;

        }
    }
}
