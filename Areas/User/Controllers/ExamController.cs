using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVC_Core_User_Profile.Areas.StudentArea.Controllers
{
    [Area("User")]
    public class ExamController : Controller
    {
        private readonly IExamService examServices;
        private readonly ITopicService topicService;
        private readonly ITopicContentService topicContentService;
        private readonly IContent_questionsService contentQuestionsService;

        public ExamController(IExamService services, ITopicService topicService, ITopicContentService topicContentService, IContent_questionsService contentQuestionsService)
        {
            examServices = services;
            this.topicService = topicService;
            this.topicContentService = topicContentService;
            this.contentQuestionsService = contentQuestionsService;
        }

        public IActionResult Index()
        {
            ViewData["topics"] = GetTopics();
            return View();
        }

        [HttpPost]
        public IActionResult Index(int topic_id)
        {
            string username = HttpContext.Session.GetString("username");
            TblTopic t = topicService.GetTopicById(topic_id);

            List<QuestionModel> lst = GetExamQuestions(topic_id, 20);
            ExamModel em = new ExamModel()
            {
                student_name = username,
                topic_id = t.TopicId,
                topic_name = t.TopicName,
                questions = lst,
                start_date = DateTime.Now,
                start_time = DateTime.Now.ToLongTimeString()
            };

            HttpContext.Session.SetString("exam", JsonConvert.SerializeObject(em));
            return RedirectToAction("StartExam");
        }

        public IActionResult StartExam()
        {
            string emString = HttpContext.Session.GetString("exam");
            if (!string.IsNullOrEmpty(emString))
            {
                ExamModel em = JsonConvert.DeserializeObject<ExamModel>(emString);
                return View(em);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SubmitExam(List<QuestionModel> questions)
        {
            string emString = HttpContext.Session.GetString("exam");

            if (!string.IsNullOrEmpty(emString))
            {
                ExamModel em = JsonConvert.DeserializeObject<ExamModel>(emString);

                List<TblUserExamQuestion> lst = new List<TblUserExamQuestion>();
                foreach (QuestionModel q in questions)
                {
                    TblUserExamQuestion sd = new TblUserExamQuestion()
                    {
                        QuestionId = q.question_id,
                        SubmitedOptionNumber = q.submitted_option_number
                    };
                    lst.Add(sd);
                }

                TblUserExam m = new TblUserExam()
                {
                    UserId = em.student_id,
                    ExamDate = em.start_date,
                    StartTime = em.start_time,
                    TopicId = em.topic_id,
                    EndTime = DateTime.Now.ToLongTimeString(),
                    TblUserExamQuestions = lst
                };

                examServices.AddQuestion(m);

                HttpContext.Session.Remove("exam");

                return Content("Exam Submitted Successfully");
            }

            return RedirectToAction("Index");
        }

        public IActionResult SetModelInViewData()
        {
            ExamModel examModel = new ExamModel(); // Your exam model instance

            // Replace "YourSessionModel" with the actual model type you are using for session data
            List<ExamModel> sessionModelList = HttpContext.Session.Get<List<ExamModel>>(WC.SessionData) ?? new List<ExamModel>();

            ViewData["ExamModel"] = JsonConvert.SerializeObject(examModel);
            ViewData["topics"] = GetTopics();
            return View("Index");
        }

        public IActionResult GetModelFromViewData()
        {
            if (ViewData["ExamModel"] != null)
            {
                string serializedModel = ViewData["ExamModel"].ToString();

                if (!string.IsNullOrEmpty(serializedModel))
                {
                    ExamModel examModel = JsonConvert.DeserializeObject<ExamModel>(serializedModel);
                    // Use examModel as needed
                }
            }

            ViewData["topics"] = GetTopics();
            return View("Index");
        }

        private List<SelectListItem> GetTopics()
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

        private List<QuestionModel> GetExamQuestions(int topic_id, int size)
        {
            List<QuestionModel> questions = new List<QuestionModel>();
            var query = from t in topicService.GetAllTopics()
                        join c in topicContentService.GetAllTopicContents() on t.TopicId equals c.TopicId
                        join q in contentQuestionsService.GetAllQuestions() on c.ContentId equals q.ContentId
                        where t.TopicId.Equals(topic_id)
                        select new
                        {
                            topic_id = t.TopicId,
                            topic_name = t.TopicName,
                            content_id = c.ContentId,
                            content_name = c.ContentName,
                            question_id = q.QuestionId,
                            question = q.Question,
                            option1 = q.Option1,
                            option2 = q.Option2,
                            option3 = q.Option3,
                            option4 = q.Option4,
                            correct_option_number = q.CorrectOptionNumber
                        };

            foreach (var q in query)
            {
                QuestionModel m = new QuestionModel()
                {
                    content_id = q.content_id,
                    content_name = q.content_name,
                    option1 = q.option1,
                    option2 = q.option2,
                    option3 = q.option3,
                    option4 = q.option4,
                    question = q.question,
                    question_id = q.question_id,
                    topic_id = q.topic_id,
                    topic_name = q.topic_name,
                    correct_option_number = (int)q.correct_option_number
                };

                questions.Add(m);
            }

            List<QuestionModel> lst = new List<QuestionModel>();
            while (lst.Count != size)
            {
                Random r = new Random();
                int i = r.Next(0, questions.Count - 1);
                QuestionModel qm = questions[i];

                if (lst.IndexOf(qm) == -1)
                {
                    lst.Add(qm);
                }
            }

            return lst;
        }
    }
}
