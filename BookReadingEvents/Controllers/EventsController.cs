using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;

using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventData eventData;
        private readonly IUserData userData;
        private User user;

        public EventsController(IEventData eventData , IUserData userData) {
            this.eventData = eventData;
            this.userData = userData;
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

    }
}