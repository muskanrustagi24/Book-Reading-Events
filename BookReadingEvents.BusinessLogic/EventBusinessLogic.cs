﻿using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.BusinessLogic
{
    public class EventBusinessLogic
    {
        private readonly IEventData eventData;

        public EventBusinessLogic()
        {
            eventData = new DummyEventData();
        }

        public IEnumerable<Event> GetAllPublicEvents() {
            var events = eventData.GetPublicEvents();
            return events;
        }

        public IEnumerable<Event> GetAllEventsCreatedByUser(Guid userId) {
            return null;
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

        public IEnumerable<Event> GetPublicEvents()
        {
            return this.eventData.GetPublicEvents();
        }

        public void UpdateEvent(Event event_)
        {
            this.eventData.UpdateEvent(event_);
        }
    }
}
