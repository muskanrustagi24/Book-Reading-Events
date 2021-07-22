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
        private readonly InvitessBusinessLogic inviteesBusinessLogic;
        public TableDataController()
        {
            eventBusinessLogic = new EventBusinessLogic();
            inviteesBusinessLogic = new InvitessBusinessLogic();
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

        [HttpGet]
        public ActionResult Delete(Guid eventId)
        {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid eventId, FormCollection form)
        {
            inviteesBusinessLogic.DeleteInvitees(eventId);
            eventBusinessLogic.DeleteEvent(eventId);
            return RedirectToAction("MyEvents", "Events");
        }
    }
}