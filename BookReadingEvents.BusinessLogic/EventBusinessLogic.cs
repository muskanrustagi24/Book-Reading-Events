using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.BusinessLogic
{
    class EventBusinessLogic
    {
        private readonly IEventData eventData;

        public EventBusinessLogic(IEventData eventData)
        {
            this.eventData = eventData;
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
