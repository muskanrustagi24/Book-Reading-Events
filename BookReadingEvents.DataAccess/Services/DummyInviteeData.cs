using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
   public class DummyInviteeData : IInviteeDataAccess
    {
        private readonly IEnumerable<Invitee> inviteeList;
        public DummyInviteeData() {
            inviteeList = new List<Invitee>();
        }

        public void DeleteInvitees(Guid eventId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guid> GetInvitedToInvents(string email)
        {
            var events = from i in inviteeList
                         where i.InviteeEmail == email
                         select i.EventId;
            return events;
        }

        public void SaveInvitees(string[] invitees, Guid eventId)
        {
            foreach (string invitee in invitees) {
                Invitee newInvitee = new Invitee
                {   InviteeEmail = invitee,
                    EventId = eventId
                };
                inviteeList.Append(newInvitee);
            }

            Console.WriteLine(inviteeList);
        }
    }
}
