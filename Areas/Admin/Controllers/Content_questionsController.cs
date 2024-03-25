using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;

namespace MVCCoreUserProfile.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Content_questionsController : Controller
    {
        IContent_questionsService _contentQuestionsServices;
        ITopicContentService _topicContentsServices;
        ITopicService _topicsServices;

        public Content_questionsController(IContent_questionsService contentQuestionsServices, ITopicContentService topicContentsServices, ITopicService topicsServices)
        {
            _contentQuestionsServices = contentQuestionsServices;
            _topicContentsServices = topicContentsServices;
            _topicsServices = topicsServices;
        }






        public IActionResult Index()
        {
            ViewBag.topic = GetTopics();
            List<TblContentQuestion> questions = _contentQuestionsServices.GetAllQuestions();
            return View(questions);
        }
        public List<SelectListItem> GetTopics()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (TblTopic t in _topicsServices.GetAllTopics())
            {
                SelectListItem s = new SelectListItem() { Text = t.TopicName, Value = t.TopicId.ToString() };
                lst.Add(s);
            }
            return lst;
        }

        public JsonResult GetTopicWiseContents(int topicid)
        {
            List<SelectListItem> lst = new List<SelectListItem>();

            List<TblTopicContent> contents = _topicContentsServices.GetAllTopicContents().Where(e => e.TopicId.Equals(topicid)).ToList();

            foreach (TblTopicContent c in contents)
            {
                SelectListItem s = new SelectListItem() { Text = c.ContentName, Value = c.ContentId.ToString() };
                lst.Add(s);
            }

            return Json(lst);
        }







        [HttpPost]
        public string AddQuestion([FromBody] TblContentQuestion q)
        {
            _contentQuestionsServices.AddQuestion(q);
            return "Question  Added Successfully";
        }
    }
}
