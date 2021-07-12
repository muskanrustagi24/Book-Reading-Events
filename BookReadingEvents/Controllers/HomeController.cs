using BookReadingEvents.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}