using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class GendersController : Controller
    {
        IGenderService GenderService;
        public GendersController(IGenderService genderService)
        {
            GenderService = genderService;
        }

        public IActionResult Index()
        {
            List<Tblgender> lst = GenderService.GetGenders();
            return View(lst);
        }

        [HttpPost]
        public string AddGender(Tblgender g)
        {

            GenderService.AddGender(g);
            return "Gender Added Successfully";
        }
    }
}
