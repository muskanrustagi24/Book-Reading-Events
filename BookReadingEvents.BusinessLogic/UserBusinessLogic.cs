using BookReadingEvents.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly IUserData userData;

        public UserBusinessLogic(IUserData userData) {
            this.userData = userData;
        }
    
        
    
    
    }
}
