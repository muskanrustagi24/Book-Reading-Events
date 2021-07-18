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
        private User user;

        public EventsController() {
            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
        }

        public ActionResult Index(Guid id)
        {
            user = userData.GetUserById(id); 
            var model = eventData.GetPublicEvents();
            return View(model);
        }
                      

        public ActionResult MyEvents()
        { 
            var model = eventData.GetAll();
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