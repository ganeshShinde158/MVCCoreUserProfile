using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreUserProfile.Models;
using MVCCoreUserProfile.Services.Implementations;
using MVCCoreUserProfile.Services.Interfaces;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;

namespace MVCCoreUserProfile.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        IUserDetailsService userDetailsService;
        IGenderService genderService;
        public UserController(IUserDetailsService userDetailsService, IGenderService genderService)
        {
            this.userDetailsService = userDetailsService;
            this.genderService = genderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            string code = GenerateUserName();
            TbluserDetail e = new TbluserDetail() { UserName = code };

            
            ViewBag.AllGenders = GetGenderList();

            var allEmployees = userDetailsService.GetUserDetails();
            if (allEmployees != null)
            {
                ViewBag.AllEmployees = allEmployees;
            }
            else
            {
                ViewBag.AllEmployees = new List<TbluserDetail>();
            }

            return View(e);
        }

        [HttpPost]
        public IActionResult Register(TbluserDetail e, IFormFile photo, int GenderId)
        {
            if (photo != null)
            {
                string imgname = e.FullName + Path.GetExtension(photo.FileName);
                string imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photo", imgname);
                using (var stream = new FileStream(imgpath, FileMode.Create))
                {
                    photo.CopyTo(stream);
                }
                e.ProfilePhoto = imgname;
            }

            string password = GeneratePassword(10);
            e.Password = password;

            
            e.GenderId = GenderId;

            userDetailsService.AddUserDetails(e);

            string msg = $"<h2>Dear {e.FullName}</h2>,<p>Your Account Has been Successfully created</p><p>You Can Access Your Account By Following Credentials</p><p>Employee Code:<b>{e.UserName}</b></br>Password:<b>{e.Password}</b></p><p>Thanks and Regards</p>";
            string subject = "Employee Account Registration";
            Send_Email(e.EmailAddress, subject, msg);

            ViewBag.msg = "Account Has Been Created Successfully,You Can Access Your Email FOR Further Access ";
            ViewBag.AllEmployees = userDetailsService.GetUserDetails();

            ModelState.Clear();
            string code = GenerateUserName();
            TbluserDetail em = new TbluserDetail() { UserName = code };

           
            ViewBag.AllGenders = GetGenderList();
            ViewBag.msg = "Account Has Been Created Successfully. You can now log in!";


            //return RedirectToAction("UserLogin");
            //return RedirectToAction(nameof(Action1));
            return RedirectToAction("UserDashboard", "UserLogin");







        }
        public List<SelectListItem> GetGenderList()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            foreach (Tblgender t in genderService.GetGenders())
            {
                SelectListItem item = new SelectListItem
                {
                    Text = t.Gender,
                    Value = t.GenderId.ToString()
                };
                lst.Add(item);
            }

            return lst;
        }
        public string GeneratePassword(int size)
        {
            string data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890$@*";
            Random r = new Random();
            return new string(Enumerable.Repeat(data, size)
              .Select(s => s[r.Next(s.Length)]).ToArray());
        }
        public static void Send_Email(string email, string subject, string description)
        {
            var fromAddress = new MailAddress("ganeshshinde158200@gmail.com", "Bankar Brothers Solutions");
            var toAddress = new MailAddress(email, email);

            MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = description,
                IsBodyHtml = true
            };

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                EnableSsl = true,
                Credentials = new NetworkCredential
                {
                    UserName = "ganeshshinde158200@gmail.com",
                    Password = "cfgnsryydegswbcv"
                },
                Port = 587
            };

            smtp.Send(message);
        }
        public string GenerateUserName()
        {
            string prefix = "U";

            var users = userDetailsService.GetUserDetails();

            if (users.Any())
            {
                var lastUser = users.OrderByDescending(u => u.UserId).First();
                int nextId = lastUser.UserId + 1;

                return $"{prefix}{nextId:D4}";
            }
            else
            {
                return $"{prefix}0001";
            }
        }
       





    }
}
