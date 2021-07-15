using BookReadingEvents.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventData eventData;

        public EventsController(IEventData eventData) {
            this.eventData = eventData;
        }

        // GET: Events
        public ActionResult Index()
        {
            var model = eventData.GetPublicEvents();
            return View(model);
        }

        public ActionResult MyEvents()
        { 
            var model = eventData.GetAll();

            return View(model);
        }

        public ActionResult Details(Guid id) {

            var model = eventData.GetEventById(id);
            return View(model);
        }
    
    }
}