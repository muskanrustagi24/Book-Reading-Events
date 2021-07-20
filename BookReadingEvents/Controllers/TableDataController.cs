using BookReadingEvents.BusinessLogic;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class TableDataController : Controller
    {
        private readonly EventBusinessLogic eventBusinessLogic;
        public TableDataController()
        {
            eventBusinessLogic = new EventBusinessLogic();
        }

        public ActionResult Index() {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(Guid eventId) {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }

        public ActionResult Edit(Event newEvent) {
            eventBusinessLogic.UpdateEvent(newEvent);
            return RedirectToAction("MyEvents" , "Events"); 
        }
        
        public ActionResult Detail(Guid eventId)
        {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }
    }
}