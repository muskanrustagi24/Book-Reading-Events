using BookReadingEvents.BusinessLogic;
using BookReadingEvents.Domain;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class LoginController : Controller
    {
        
        private readonly UserBusinessLogic userBusinessLogic;
        private readonly EventBusinessLogic eventBusinessLogic;
       
        public LoginController() {
           userBusinessLogic = new UserBusinessLogic();
            eventBusinessLogic = new EventBusinessLogic();
        }

        [HttpGet]
        public ActionResult Index()
        {   
           return View();
        }

        [HttpPost]
        public ActionResult Index(User user) {

            User existingUser = userBusinessLogic.GetUserByEmail(user.Email);
                  
            if (existingUser != default)
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

            userBusinessLogic.SignUpUser(user);
           
            bool doesUserExist = userBusinessLogic.IsUserValid(user);

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
        public ActionResult AllEventsBeforeLogin() {
            var model = eventBusinessLogic.GetAllPublicEvents();
            return View(model);
        }
    
    
    }
}