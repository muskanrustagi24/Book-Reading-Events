using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class SqlEventData : IEventData
    {
        private readonly BookReadingEventsContext eventData;

        public SqlEventData(BookReadingEventsContext eventData)
        {
            this.eventData = eventData;
        }

        public void AddEvent(Event event_)
        {
            eventData.Events.Add(event_);
            eventData.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return eventData.Events.OrderBy(e => e.EventId);
        }

        public IEnumerable<Event> GetEventById(Guid id)
        {
            return from e in eventData.Events
                   where e.UserId == id
                   select e;
        }

        public IEnumerable<Event> GetPublicEvents()
        {
            return from e in eventData.Events
                   where e.TypeOfEvent == EventType.Public
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
