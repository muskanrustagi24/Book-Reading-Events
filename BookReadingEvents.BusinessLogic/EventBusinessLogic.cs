using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.BusinessLogic
{
    public class EventBusinessLogic
    {
        private readonly IEventData eventData;

        public EventBusinessLogic() {
            eventData = new DummyEventData();
        }

        public IEnumerable<Event> GetAllPublicEvents() {
            var events = eventData.GetPublicEvents();
            return events;
        }

        public IEnumerable<Event> GetAllEventsCreatedByUser(Guid userId) {
            var events = eventData.GetEventsCreatedByUser(userId);
            return events;
        }

    
    }
}
