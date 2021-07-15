using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.Domain.Services
{
   public interface IEventData
    {
        IEnumerable<Event> GetAll();

        Event GetEventById(Guid id);

        IEnumerable<Event> GetPublicEvents();

   }
}
