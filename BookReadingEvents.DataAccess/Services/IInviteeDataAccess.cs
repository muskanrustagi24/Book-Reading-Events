using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.DataAccess.Services
{
    public interface IInviteeDataAccess
    {
        void SaveInvitees(string[] invitees, Guid eventId);

        IEnumerable<Guid> GetInvitedToInvents(string email);
      
        void DeleteInvitees(Guid eventId);
    }
}
