using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace MVCCoreUserProfile.Services.Implementations
{
    public class CityService : ICityService
    {
        IRepository<Tblcity> cityrepo;
        public CityService(IRepository<Tblcity> cityrepo)
        {
            this.cityrepo = cityrepo;
        }

        public void AddCity(Tblcity city)
        {
            cityrepo.Create(city);


        }

        public void DeleteCity(int city_Id)
        {
            cityrepo.Delete(city_Id);
        }

        public List<Tblcity> GetCities()
        {
            return cityrepo.GetAll();
        }

        public Tblcity GetCityById(int city_Id)
        {
           return cityrepo.GetById(city_Id);
        }

        public void UpdateCity(Tblcity city)
        {
            cityrepo.Update(city);
        }
    }
}
