using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly UserBusinessLogic userBusinessLogic;
        private readonly EventBusinessLogic eventBusinessLogic;
        private User user;

        public EventsController() {
           
            userBusinessLogic = new UserBusinessLogic();
            eventBusinessLogic = new EventBusinessLogic();
        }

        [HttpGet]
        public ActionResult Index() {
            var model = eventBusinessLogic.GetAllPublicEvents();
            return View(model);
        }

        public ActionResult Index(Guid id)
        {
            user = userBusinessLogic.GetUserByUserId(id);
            System.Diagnostics.Debug.WriteLine(user);
            var model = eventBusinessLogic.GetAllPublicEvents();
            return View(model);
        }
                      

        public ActionResult MyEvents()
        {
            var model = eventBusinessLogic.GetAllEventsCreatedByUser(user.UserId);
            System.Diagnostics.Debug.WriteLine(user);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Event event_)
        {
            eventBusinessLogic.AddEvent(event_);
            return View();
        }

    }
}