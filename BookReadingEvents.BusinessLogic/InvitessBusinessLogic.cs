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
      
        private readonly IInviteeDataAccess sqlInvitee;

        public InvitessBusinessLogic() {
           
            sqlInvitee = new InviteeDataAccess();
        }

        public void SaveInvitees(string invitees , Guid eventId ){
            if (invitees.Length > 0) {
                string[] inviteeArray = invitees.Split(',');
                sqlInvitee.SaveInvitees(inviteeArray, eventId);
            }
        }

        public IEnumerable<Guid> GetInvitedToEvents(string email) {
           var invitedTo = sqlInvitee.GetInvitedToInvents(email);
           return invitedTo;
        }
        
        public void DeleteInvitees(Guid eventId)
        {
            sqlInvitee.DeleteInvitees(eventId);
        }
    }
}
