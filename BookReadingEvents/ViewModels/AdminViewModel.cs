using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReadingEvents.ViewModels
{
    public class AdminViewModel
    {
        public Event Event { get; set; }

        public User User { get; set;}
    }
}