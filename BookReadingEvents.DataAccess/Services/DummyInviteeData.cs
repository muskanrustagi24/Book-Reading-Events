using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.DataAccess.Services
{
   public class DummyInviteeData : IInviteeData
    {
        private readonly IEnumerable<Invitee> inviteeList;
        public DummyInviteeData() {
            inviteeList = new List<Invitee>();
        }

        public IEnumerable<Event> GetInvitedToInvents(string email)
        {
            var events = from i in inviteeList
                         where i.InviteeEmail == email
                         select i.Event;
            return events;
        }

        public void SaveInvitees(string[] invitees, Guid eventId)
        {
            foreach (string invitee in invitees) {
                Invitee newInvitee = new Invitee
                {   InviteeEmail = invitee,
                    Event = myEvent,
                    EventId = eventId
                };
                inviteeList.Append(newInvitee);
            }

            Console.WriteLine(inviteeList);
        }
    }
}
