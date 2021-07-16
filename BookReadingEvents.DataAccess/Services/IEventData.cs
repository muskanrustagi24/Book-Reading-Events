using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.DataAccess.Services
{
    public interface IEventData
    {
        IEnumerable<Event> GetAll();

        Event GetEventById(Guid id);

        IEnumerable<Event> GetPublicEvents();
    
        void AddEvent(Event event_);

    }
}
