using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class InviteeDataAccess : IInviteeDataAccess
    {
        private readonly BookReadingEventsDbContext inviteeData;

        public InviteeDataAccess()
        {
            inviteeData = new BookReadingEventsDbContext();
        }

        public void DeleteInvitees(Guid eventId)
        {
            IEnumerable<Invitee> inviteesToBeDeleted = from i in inviteeData.Invitees
                                                       where i.EventId == eventId
                                                       select i;

            foreach (var invitee in inviteesToBeDeleted)
            { 
                inviteeData.Invitees.Remove(invitee);
               
            }

            inviteeData.SaveChanges();
        }

        public IEnumerable<Guid> GetInvitedToInvents(string email)
        {
            return from i in inviteeData.Invitees
                   where i.InviteeEmail == email
                   select i.EventId;
        }

        public void SaveInvitees(string[] invitees, Guid eventId)
        {
            foreach (string invitee in invitees)
            {
                var newInvitee = new Invitee
                {
                    InviteeEmail = invitee,
                    EventId = eventId
                };

                inviteeData.Invitees.Add(newInvitee);
                inviteeData.SaveChanges();
            }
        }
    }
}
