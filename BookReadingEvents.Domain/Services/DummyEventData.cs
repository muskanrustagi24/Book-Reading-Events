using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReadingEvents.Domain.Enums;

namespace BookReadingEvents.Domain.Services
{
    public class DummyEventData : IEventData
    {
        IEnumerable<Event> events;

        public DummyEventData()
        {
            this.events = new List<Event>()
            {
                new Event{Title = "Event 1" , Date = new DateTime(2021 , 11 , 21) , Description = "abc" , Duration = 2 , Location = "Gurgaon" , TypeOfEvent = EventType.Public },
                new Event{Title = "Event 2" , Date = new DateTime(2021 , 11 , 22) , Description = "abc" , Duration = 2 , Location = "Noida" , TypeOfEvent = EventType.Private },
                new Event{Title = "Event 3" , Date = new DateTime(2021 , 11 , 23) , Description = "abc" , Duration = 2 , Location = "Noida" , TypeOfEvent = EventType.Public }
            };
        }
        public IEnumerable<Event> GetAll()
        {
            return events.OrderBy(e => e.Date);
        }

        public Event GetEventById(Guid id)
        {
            var evnt = events.FirstOrDefault(e => e.EventId == id);
            return evnt;
        }

        public IEnumerable<Event> GetPublicEvents()
        {
            var publicEvents = from e in events
                               where e.TypeOfEvent == EventType.Public
                               select e;

            return publicEvents;
        }
    }
}
