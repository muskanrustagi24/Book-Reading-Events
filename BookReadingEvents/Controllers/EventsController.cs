using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace BookReadingEvents.Controllers
{
    public class EventsController : Controller
    {
        
        private readonly EventBusinessLogic eventData;
        private readonly UserBusinessLogic userData;
        private readonly InvitessBusinessLogic inviteeData;
    
        public EventsController() {
            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
            inviteeData = new InvitessBusinessLogic();
           
        }

        public ActionResult Index()
        {            
            var model = eventData.GetPublicEvents();
            return View(model);
        }

        public ActionResult RenderEventsPartialView() {
            return PartialView("_EventsPartialView");
        }

        public ActionResult MyEvents()
        {
            var model = eventData.GetAllEventsCreatedByUser(Guid.Parse(Session["Id"].ToString()));
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateEventViewModel viewModel)
        {
            Event myEvent = new Event
            {
                Title = viewModel.Event.Title,
                Description = viewModel.Event.Description,
                Duration = viewModel.Event.Duration,
                Date = DateTime.Parse(viewModel.Date),
                Location = viewModel.Event.Location,
                OtherDetails = viewModel.Event.OtherDetails,
                TypeOfEvent = viewModel.Event.TypeOfEvent,
                UserId = Guid.Parse(Session["Id"].ToString()),
            };

             if (ModelState.IsValid) {
                eventData.AddEvent(myEvent);
                inviteeData.SaveInvitees(viewModel.Invitees , myEvent.EventId);
                return RedirectToAction("MyEvents");
            }

            return View();
        }
        
        public ActionResult EventsInvitedTo()
        {
            var eventIds = inviteeData.GetInvitedToEvents(Session["Email"].ToString());

            var model = eventData.GetAllEventsByEventIds(eventIds);

            return View(model);
        }

        public ActionResult Logout() {
            Session["Email"] = null;
            Session["Id"] = null;
            return RedirectToAction("AllEventsBeforeLoginSignup","Login");
        }
    
    }
}