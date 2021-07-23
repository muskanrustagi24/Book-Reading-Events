using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BookReadingEvents.BusinessLogic
{
    public class EventBusinessLogic
    {
        private readonly IEventDataAccess eventData;

        public EventBusinessLogic()
        {
            eventData = new EventDataAccess();
        }

        public IEnumerable<Event> GetAllPublicEvents() {
            var events = eventData.GetPublicEvents();
            return events;
        }

        public IEnumerable<Event> GetAllEventsCreatedByUser(Guid userId) {
            var events = GetAll();
            var evnts = from e in events
                        where e.UserId == userId
                        select e;
            return evnts;
        }

        public void AddEvent(Event event_)
        {
           eventData.AddEvent(event_);
        }

        public IEnumerable<Event> GetAll()
        {
            return this.eventData.GetAll();
        }

        public IEnumerable<Event> GetEventById(Guid id)
        {
            return this.eventData.GetEventsByUser(id);
        }

        public Event GetEventByEventId(Guid id) {

            return eventData.GetEventByEventId(id);
        }


        public IEnumerable<Event> GetPublicEvents()
        {
            return this.eventData.GetPublicEvents();
        }

        public IEnumerable<Event> GetPrivateEvents() {
            var events = from e in GetAll()
                         where e.TypeOfEvent == Domain.Enums.EventType.Private
                         select e;
            return events;
        }


        public void UpdateEvent(Event event_)
        {
            this.eventData.UpdateEvent(event_);
        }

        public void DeleteEvent(Guid id)
        {
            this.eventData.DeleteEvent(id);
        }
      
        public IEnumerable<Event> GetAllUpcomingEvents() { 
            var upcomingEvents = from e in eventData.GetAll()
                                 where e.Date > DateTime.Now
                                 select e;
            return upcomingEvents;
        }

        public IEnumerable<Event> GetAllPastEvents() {
            var pastEvents = from e in eventData.GetAll()
                             where e.Date < DateTime.Now
                             select e;
            return pastEvents;
        }

        public IEnumerable<Event> GetAllEventsByEventIds(IEnumerable<Guid> eventIds) {
            return from e in eventIds
                        select GetEventByEventId(e);
         
        }

    }
}
