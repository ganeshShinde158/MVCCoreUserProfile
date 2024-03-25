using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface IUserDetailsService
    {
        void AddUserDetails(TbluserDetail userDetails);
        void UpdateUserDetails(TbluserDetail userDetails);
        void DeleteUserDetails(int userDetails_Id);
        List<TbluserDetail> GetUserDetails();
        TbluserDetail GetUserDetailsById(int userDetailsId);

        void AddUserDetailWithGender(TbluserDetail userDetails, int genderId);
        void UpdateUserDetailWithGender(TbluserDetail userDetails, int genderId);

        List<TbluserDetail> GetUserDetailsByGender(int genderId);
        bool ValidateCredentials(string empcode, string password, out TbluserDetail employee);


    }
}
