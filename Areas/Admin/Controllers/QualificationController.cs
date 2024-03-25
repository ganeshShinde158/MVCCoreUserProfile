using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QualificationController : Controller
    {
        IQualificationService QualificationService;
        public QualificationController(IQualificationService qualificationService)
        {
            QualificationService = qualificationService;
        }

        public IActionResult Index()
        {
            List<Tblqualification> lst = QualificationService.GetQualifications();
            return View(lst);
        }

        [HttpPost]
        public string AddQualification(Tblqualification q)
        {

            QualificationService.AddQualification(q);
            return "Qualification Added Successfully";
        }
    }
}
