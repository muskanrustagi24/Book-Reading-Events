using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class EventDataAccess : IEventDataAccess
    {
        private readonly BookReadingEventsDbContext eventData;

        public EventDataAccess()
        {
            this.eventData = new BookReadingEventsDbContext();
        }

        public void AddEvent(Event event_)
        {
            eventData.Events.Add(event_);
            eventData.SaveChanges();
        }

        public void DeleteEvent(Guid id)
        {
            var event_ = eventData.Events.Find(id);
            eventData.Events.Remove(event_);
            eventData.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return eventData.Events.OrderBy(e => e.EventId);
        }

        public Event GetEventByEventId(Guid id)
        {
            return eventData.Events.FirstOrDefault(e => e.EventId.Equals(id));
        }

        public IEnumerable<Event> GetEventsByUser(Guid id)
        {
            return from e in eventData.Events
                   where e.UserId == id
                   select e;
        }

        public IEnumerable<Event> GetPublicEvents()
        {
            return from e in eventData.Events
                   where e.TypeOfEvent == EventType.Public
                   orderby e.Date descending
                   select e;
        }

        public void UpdateEvent(Event event_)
        {
            var entry = eventData.Entry(event_);
            entry.State = EntityState.Modified;
            eventData.SaveChanges();
        }
    }
}
