using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using BookReadingEvents.ViewModels;
using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class LoginController : Controller
    {
      
        private readonly UserBusinessLogic userData;
        private readonly EventBusinessLogic eventData;
       
        public LoginController() {

            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
          
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            User user = new User
            {
                Email = viewModel.Email,
                Password = viewModel.Password 

            };

            if (ModelState.IsValid)
            {
                int loginFlag = userData.LoginVerifications(user);

                if (loginFlag == 0)
                {
                    user = userData.GetUserByEmail(user.Email);
                    Session["Email"] = user.Email;
                    Session["Id"] = user.UserId;
                    return RedirectToAction("Index", "Events");
                }
                else if (loginFlag == 1)
                {
                    user = userData.GetUserByEmail(user.Email);
                    Session["Email"] = user.Email;
                    Session["Id"] = user.UserId;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.Message = "The user does not exist!";
                    return View();
                }
            }
            else {
                return View();
            }
         
           
        }

        [HttpGet]
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User viewModel) {

            User user = new User
            {
                Email = viewModel.Email,
                Password = viewModel.Password
            };

            if (ModelState.IsValid)
            {
                int canUserBeAdded = userData.SignUpVerifications(user);

                if (canUserBeAdded == -1)
                {
                    ViewBag.Message = "Error!! A user with same email already exists!";
                    //same email
                    return View();
                }
                else if (canUserBeAdded == 0)
                {
                 
                        userData.AddUser(user);
                        user = userData.GetUserByEmail(user.Email);
                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        return RedirectToAction("Index", "Events");
                   


                }
                else
                {
                        userData.AddUser(user);
                        user = userData.GetUserByEmail(user.Email);
                        Session["Email"] = user.Email;
                        Session["Id"] = user.UserId;
                        return RedirectToAction("Index", "Admin");
                   
                }
            }
            else
            {
                return View();
            }
          
            }
        

        [HttpGet]
        public ActionResult AllEventsBeforeLoginSignup()
        {
            var model = eventData.GetAllPublicEvents();
            return View(model);
        }

        public ActionResult RenderEventsPartialView() {
            return PartialView("_EventsBeforeLoginSignupPartialView");
        }
        
        [HttpGet]
        public ActionResult Details(Guid eventId) {
            Event myEvent = eventData.GetEventByEventId(eventId);
            return View(myEvent);
        }
    
    }
}