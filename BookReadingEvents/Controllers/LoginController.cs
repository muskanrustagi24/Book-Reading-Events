using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class LoginController : Controller
    {
      
        private UserBusinessLogic userData;
        private EventBusinessLogic eventData;
       
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
        public ActionResult Index(User user) {

            bool doesUserExist = userData.DoesUserExist(user);

            if (doesUserExist)
            {
                return RedirectToAction("Index", "Events", new { id = user.UserId });
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
        public ActionResult SignUp(User user) {
           
            userData.AddUser(user);

            bool doesUserExist = userData.DoesUserExist(user);

            if (doesUserExist)
            {
                return RedirectToAction("Index", "Events", new { id = user.UserId });
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
    }
}