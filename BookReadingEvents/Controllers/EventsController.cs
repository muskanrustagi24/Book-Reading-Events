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
            myEvent.Date = DateTime.Parse(viewModel.Event.Date.ToString());
            User user = userData.GetUserByEmail(Session["Email"].ToString());
         
                  myEvent.UserId = user.UserId;

            //We have to save event before saving invitees
            eventData.AddEvent(myEvent);

           
            //if length of string > 0 then we will save our invitees
            if (viewModel.Invitees.Length > 0) {
                string[] inviteesList = viewModel.Invitees.Split(',');
                inviteeData.SaveInvitees(inviteesList, myEvent.EventId);
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
    }
}