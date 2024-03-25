using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CitiesController : Controller
    {
        ICityService CityService;
        public CitiesController(ICityService cityService)
        {
            CityService = cityService;
        }

        public IActionResult Index()
        {
            List<Tblcity> lst = CityService.GetCities();
            return View(lst);
        }
        [HttpPost]
        public string AddCity(Tblcity c)
        {

            CityService.AddCity(c);
            return "City Added Successfully";
        }
    }
}
