﻿using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using BookReadingEvents.ViewModels;
using System;
using System.Web.Mvc;

namespace BookReadingEvents.Controllers
{
    public class LoginController : Controller
    {
      
        private readonly UserBusinessLogic userData;
        private readonly EventBusinessLogic eventData;
       
        public LoginController() {

            userData = new UserBusinessLogic();
            eventData = new EventBusinessLogic();
          
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel viewModel)
        {
            User user = userData.IsUserVerified(viewModel.Email, viewModel.Password);
            
            if (user == null)
            {
                return View();
            }

            if (user.Role == UserType.Admin) {
                return RedirectToAction("Index", "Admin");
            }

           

            Session["Email"] = viewModel.Email;
            Session["Id"] = user.UserId;
            return RedirectToAction("Index", "Events");
        }

        [HttpGet]
        public ActionResult SignUp() {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User viewModel) {
            bool isAdmin = viewModel.Email.Contains("admin");
            
            if (isAdmin)
            {
                viewModel.Role =  UserType.Admin;
            }
            else {
                viewModel.Role = UserType.Normal;
            }
            
            userData.AddUser(viewModel);

            bool doesUserExist = userData.DoesUserExist(viewModel);

            if (doesUserExist)
            {
                Session["Email"] = viewModel.Email;
                Session["Id"] = viewModel.UserId;
                return RedirectToAction("Index", "Events");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult AllEventsBeforeLoginSignup()
        {
            var model = eventData.GetAllPublicEvents();
            return View(model);
        }

        public ActionResult RenderEventsPartialView() {
            return PartialView("_EventsPartialView");
        }
        
        [HttpGet]
        public ActionResult Details(Guid id) {
            Event myEvent = eventData.GetEventByEventId(id);
            return View(myEvent);
        }
    
    }
}