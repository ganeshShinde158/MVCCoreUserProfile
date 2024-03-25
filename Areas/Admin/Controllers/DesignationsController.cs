using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DesignationsController : Controller
    {
        IDesignationService designationService;

        public DesignationsController(IDesignationService designationService)
        {
            this.designationService = designationService;
        }

        public IActionResult Index()
        {
            List<Tbldesignation> lst = designationService.GetDesignations();
            return View(lst);
        }

        [HttpPost]
        public string AddDesignation(Tbldesignation d)
        {
            
            designationService.AddDesignation(d);
            return "Designation Added Successfully";
        }
    }
}
