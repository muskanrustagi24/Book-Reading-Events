using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.ViewModels;
using System;
using System.Collections.Generic;
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
                InvitessBusinessLogic inviteeData = new InvitessBusinessLogic();
                string[] inviteesList = viewModel.Invitees.Split(',');
                inviteeData.SaveInvitees(inviteesList, myEvent.EventId);
            }
           return View();
        }
        
        public ActionResult EventsInvitedTo()
        {
            return View();
        }
    }
}