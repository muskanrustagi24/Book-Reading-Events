using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
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
        public ActionResult Index(LoginViewModel viewModel) {

            User user = userData.IsUserVerified(viewModel.Email, viewModel.Password);
            if (user == null) {
                return View();
            }
         
             Session["Email"] = viewModel.Email;
             Session["Id"] = user.UserId;
             return RedirectToAction("Index", "Events");
 
        }

        [HttpGet]
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User viewModel) {
                              

            userData.AddUser(viewModel);

            bool doesUserExist = userData.DoesUserExist(viewModel);

            if (doesUserExist)
            {
                Session["Email"] = viewModel.Email;
                Session["Id"] = viewModel.UserId;
                return RedirectToAction("Index", "Events");
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

        [HttpGet]
        public ActionResult Detail(Guid id) {

            Event myEvent = eventData.GetEventByEventId(id);
            return View(myEvent);
        }
    
    }
}