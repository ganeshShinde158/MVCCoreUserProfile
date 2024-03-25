using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TopicsController : Controller
    {
        ITopicService topicService;
        public TopicsController(ITopicService topicService)
        {
            this.topicService = topicService;
        }

        public IActionResult Index()
        {
            List<TblTopic> lst = topicService.GetAllTopics();
            return View(lst);
        }

        [HttpPost]
        public string AddTopics(TblTopic t)
        {

            topicService.AddTopic(t);
            return "Topic Added Successfully";
        }
    }
}
