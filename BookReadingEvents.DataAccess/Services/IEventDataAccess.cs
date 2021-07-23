using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.DataAccess.Services
{
    public interface IEventDataAccess
    {
        IEnumerable<Event> GetAll();

        IEnumerable<Event> GetEventsByUser(Guid id);

        IEnumerable<Event> GetPublicEvents();

        void AddEvent(Event event_);

        void UpdateEvent(Event event_);

        Event GetEventByEventId(Guid id);

        void DeleteEvent(Guid id);
    }
}
