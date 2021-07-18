﻿using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.DataAccess.Services
{
    public interface IEventData
    {
        IEnumerable<Event> GetAll();

        IEnumerable<Event> GetEventById(Guid id);

        IEnumerable<Event> GetPublicEvents();
    
        void AddEvent(Event event_);

        void UpdateEvent(Event event_);
    }
}
