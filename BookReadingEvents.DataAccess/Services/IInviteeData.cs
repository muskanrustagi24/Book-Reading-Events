﻿using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.DataAccess.Services
{
   public interface IInviteeData
    {
        void SaveInvitees(string[] invitees, Guid eventId);

        IEnumerable<Guid> GetInvitedToInvents(string email);
   }
}
