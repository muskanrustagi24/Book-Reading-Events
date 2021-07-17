﻿using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.BusinessLogic
{
    public class EventBusinessLogic
    {
        private readonly IEventData eventData;

        public EventBusinessLogic() {
            eventData = new DummyEventData();
        }

        public IEnumerable<Event> GetAllPublicEvents() {
            var events = eventData.GetPublicEvents();
            return events;
        }

        public IEnumerable<Event> GetAllEventsCreatedByUser(Guid userId) {
            var events = eventData.GetEventsCreatedByUser(userId);
            return events;
        }

        
        public void AddEvent(Event event_)
        {
            this.eventData.AddEvent(event_);
        }

        public IEnumerable<Event> GetAll()
        {
            return this.eventData.GetAll();
        }

        public IEnumerable<Event> GetEventById(Guid id)
        {
            return this.eventData.GetEventById(id);
        }

        public void UpdateEvent(Event event_)
        {
            this.eventData.UpdateEvent(event_);
        }

    }
}
