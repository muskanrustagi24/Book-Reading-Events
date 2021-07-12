using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReadingEvents.Domain.Enums;

namespace BookReadingEvents.Domain.Services
{
   public class DummyUserData : IUserData
    {
        IEnumerable<User> users;

        public DummyUserData()
        {
            users = new List<User>()
            {
                new User{Email = "abc@gmail.com"  , Password = "12344" , Role = UserType.Normal},
                new User{Email = "admin@gmail.com" , Password = "122343" , Role = UserType.Admin }
            };
        }

        public IEnumerable<User> GetAll()
        {
            return users.OrderBy(r => r.Email);
        }
    }
}
