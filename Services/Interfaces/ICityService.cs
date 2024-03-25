using MVCCoreUserProfile.Models;

namespace MVCCoreUserProfile.Services.Interfaces
{
    public interface ICityService
    {
        void AddCity(Tblcity city);
        void UpdateCity(Tblcity city);
        void DeleteCity(int city_Id);
        List<Tblcity> GetCities();
        Tblcity GetCityById(int city_Id);
       
    }
}
