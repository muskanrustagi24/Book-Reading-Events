using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.BusinessLogic
{
   public class InvitessBusinessLogic
    {
        private readonly DummyInviteeData dummyInvitee;

        public InvitessBusinessLogic() {
            dummyInvitee = new DummyInviteeData();
        }

        public void SaveInvitees(string[] invitees , Guid eventId ){
            dummyInvitee.SaveInvitees(invitees, eventId);
        }

        public IEnumerable<Guid> GetInvitedToEvents(string email) {
           return dummyInvitee.GetInvitedToInvents(email);
        }
    
    }
}
