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
        private readonly IInviteeData inviteeData;
    
        public EventsController() {
            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
            inviteeData = new SqlInviteeData();
           
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

        [HttpPost]
        public ActionResult Create(CreateEventViewModel viewModel)
        {
            Event myEvent = viewModel.Event;
            TimeSpan time = TimeSpan.Parse(viewModel.Time);
            myEvent.Date = new DateTime();
            myEvent.Date = DateTime.Parse(viewModel.Date);
            myEvent.Date.Add(time);
            
            var demo = myEvent.Date;
            User user = userData.GetUserByEmail(Session["Email"].ToString());
            myEvent.UserId = user.UserId;

            if (ModelState.IsValid) {
                eventData.AddEvent(myEvent);

                //if length of string > 0 then we will save our invitees
                if (viewModel.Invitees.Length > 0)
                {
                    InvitessBusinessLogic inviteeData = new InvitessBusinessLogic();
                    string[] inviteesList = viewModel.Invitees.Split(',');
                    inviteeData.SaveInvitees(inviteesList, myEvent.EventId);
                }
                return RedirectToAction("MyEvents");
            }
            return View();
        }
        
        public ActionResult EventsInvitedTo()
        {
            var eventIds = inviteeData.GetInvitedToInvents(Session["Email"].ToString());

            var model = from e in eventIds
                        select eventData.GetEventByEventId(e);

            return View(model);
        }

        public ActionResult Logout() {
            Session["Email"] = null;
            Session["Id"] = null;
            return RedirectToAction("AllEventsBeforeLoginSignup","Login");
        }
    
    }
}