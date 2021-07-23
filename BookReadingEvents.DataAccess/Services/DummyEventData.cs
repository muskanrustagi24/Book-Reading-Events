using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class DummyEventData : IEventDataAccess
    {
        readonly IEnumerable<Event> events;

        public DummyEventData()
        {
            this.events = new List<Event>()
            {
                new Event{Title = "Event 1" , Date = new DateTime(2021 , 11 , 21) , Description = "abc" , Duration = 2 , Location = "Gurgaon" , TypeOfEvent = EventType.Public },
                new Event{Title = "Event 2" , Date = new DateTime(2021 , 11 , 22) , Description = "abc" , Duration = 2 , Location = "Noida" , TypeOfEvent = EventType.Private },
                new Event{Title = "Event 3" , Date = new DateTime(2021 , 11 , 23) , Description = "abc" , Duration = 2 , Location = "Noida" , TypeOfEvent = EventType.Public }
            };
        }

        public void AddEvent(Event event_)
        {
            events.Append(event_);
        }

        public void DeleteEvent(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            return events.OrderBy(e => e.Date);
        }

        public Event GetEventByEventId(Guid id)
        {
            var evnt = events.FirstOrDefault(e => e.EventId == id);
            return evnt;
        }

        public IEnumerable<Event> GetEventsByUser(Guid id)
        {
            var evnt = from e in events
                       where e.UserId == id
                       select e;

            return evnt;

        }

        public IEnumerable<Event> GetPublicEvents()
        {
            var publicEvents = from e in events
                               where e.TypeOfEvent == EventType.Public
                               select e;

            return publicEvents;
        }

        public void UpdateEvent(Event event_)
        {
            throw new NotImplementedException();
        }
    }
}
