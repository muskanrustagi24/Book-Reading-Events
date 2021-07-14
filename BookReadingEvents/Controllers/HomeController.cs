using BookReadingEvents.Domain.Services;
using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class HomeController : Controller
    {
        IUserData db;

        public HomeController()
        {
            db = new DummyUserData();
        }

        public ActionResult Index()
        {
            var users = db.GetAll();

            return View(users);
        }

        public ActionResult MyEvents()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult EventsInvitedTo()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }
    }
}