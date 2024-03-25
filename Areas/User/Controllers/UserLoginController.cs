using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Interfaces;
using System.Net.Mail;

namespace MVCCoreUserProfile.Areas.User.Controllers
{
    [Area("User")]

    public class UserLoginController : Controller
    {
        IUserDetailsService userDetailsService;

        public UserLoginController(IUserDetailsService userDetailsService)
        {
            this.userDetailsService = userDetailsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email_address, string password)
        {
            try
            {
                var users = userDetailsService.GetUserDetails();
                var user = users.FirstOrDefault(u => u.UserName == email_address && u.Password == password);

                if (user != null)
                {
                    HttpContext.Session.SetString("username", user.UserName);

                    
                   // return Redirect("/User/UserLogin/UserDashboard");
                    return Redirect("/User/Exam/Index");



                }
                else if (email_address == "admin@123" && password == "admin")
                {
                    return RedirectToAction("Content_questions");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid credentials!";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = "An error occurred: " + e.Message;
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            //return RedirectToAction("Index");
            return RedirectToAction(nameof(Index));

        }

        public IActionResult UserDashboard()
        {

            if (HttpContext.Session.GetString("username") != null)
            {
                string username = HttpContext.Session.GetString("username");

                var users = userDetailsService.GetUserDetails();
                var user = users.FirstOrDefault(u => u.UserName.Equals(username));

                if (user != null)
                {
                    return View(user);
                }
            }

            return RedirectToAction("Index");
        }
    }

}

