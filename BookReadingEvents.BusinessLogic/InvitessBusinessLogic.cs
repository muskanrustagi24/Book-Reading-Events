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
      
        private readonly IInviteeData sqlInvitee;

        public InvitessBusinessLogic() {
           
            sqlInvitee = new SqlInviteeData();
        }

        public void SaveInvitees(string[] invitees , Guid eventId ){
            sqlInvitee.SaveInvitees(invitees, eventId);
        }

        public IEnumerable<Guid> GetInvitedToEvents(string email) {
           return sqlInvitee.GetInvitedToInvents(email);
        }
        
        public void DeleteInvitees(Guid eventId)
        {
            sqlInvitee.DeleteInvitees(eventId);
        }
    }
}
