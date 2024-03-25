using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class Topic_contentsController : Controller
    {
        ITopicContentService contentService;
        ITopicService topicService;

        public Topic_contentsController(ITopicContentService contentService, ITopicService topicService)
        {
            this.contentService = contentService;
            this.topicService = topicService;
        }

        public IActionResult Index()
        {
            ViewBag.states = GetTopic();
            return View(contentService.GetAllTopicContents());
        }
        public List<SelectListItem> GetTopic()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (TblTopic t in topicService.GetAllTopics())
            {
                SelectListItem s = new SelectListItem()
                {
                    Text = t.TopicName,
                    Value = t.TopicId.ToString()
                };
                lst.Add(s);
            }
            return lst;
        }
        [HttpPost]
        public string AddTopic_content(TblTopicContent tc)
        {

            contentService.AddTopicContent(tc);
            return "TopicContent Added Successfully";
        }
    }
}
