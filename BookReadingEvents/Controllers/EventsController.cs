using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly EventBusinessLogic eventData;
        private readonly UserBusinessLogic userData;
        

        public EventsController() {
            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
        }

        public ActionResult Index()
        {
             
            var model = eventData.GetPublicEvents();
            return View(model);
        }
                      

        public ActionResult MyEvents()
        {
            string userEmail = Session["Email"].ToString();
            User user = userData.GetUserByEmail(userEmail);
            var model = eventData.GetAllEventsCreatedByUser(user.UserId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Event event_)
        {
            
            return View();
        }

    }
}