using BookReadingEvents.BusinessLogic;
using BookReadingEvents.Domain;
using BookReadingEvents.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class AdminController : Controller
    {
        private readonly EventBusinessLogic eventBusinessLogic;
        private readonly UserBusinessLogic userBusinessLogic;

        public AdminController() {
            eventBusinessLogic = new EventBusinessLogic();
            userBusinessLogic = new UserBusinessLogic();
        }

        public ActionResult Index()
        {
            var events = eventBusinessLogic.GetAll();
            List<AdminViewModel> model = new List<AdminViewModel>();

            foreach (var evnt in events) {
                AdminViewModel viewModel = new AdminViewModel
                {
                    Event = evnt,
                    User = userBusinessLogic.GetUserById(evnt.UserId)
                };
                model.Add(viewModel);
            }

            return View(model);
        }

        public ActionResult FutureEvents() {
           
            var events = eventBusinessLogic.GetAllUpcomingEvents();
            List<AdminViewModel> model = new List<AdminViewModel>();

            foreach (var evnt in events)
            {
                AdminViewModel viewModel = new AdminViewModel
                {
                    Event = evnt,
                    User = userBusinessLogic.GetUserById(evnt.UserId)
                };
                model.Add(viewModel);
            }

            return View(model);

        }

        public ActionResult PastEvents() {
            var events = eventBusinessLogic.GetAllPastEvents();
            List<AdminViewModel> model = new List<AdminViewModel>();

            foreach (var evnt in events)
            {
                AdminViewModel viewModel = new AdminViewModel
                {
                    Event = evnt,
                    User = userBusinessLogic.GetUserById(evnt.UserId)
                };
                model.Add(viewModel);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(Guid eventId) {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Event newEvent) {
            eventBusinessLogic.UpdateEvent(newEvent);
            return RedirectToAction("Index");
        }

        public ActionResult Details(Guid eventId) {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(Guid eventId) {
            var model = eventBusinessLogic.GetEventByEventId(eventId);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Event myEvent) {
            eventBusinessLogic.DeleteEvent(myEvent.EventId);
            return RedirectToAction("Index");
        }
    
    }



}