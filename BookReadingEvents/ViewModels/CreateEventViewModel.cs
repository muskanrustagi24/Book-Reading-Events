using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReadingEvents.ViewModels
{
    public class CreateEventViewModel
    {
       public string Invitees { get; set; }

       public Event Event { get; set; }

       public string Date { get; set; }

       public string Time { get; set; }
            
    }
}   