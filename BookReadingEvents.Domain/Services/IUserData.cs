using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEvents.Domain.Services
{
   public interface IUserData
    {
        IEnumerable<User> GetAll();

        User GetUserById(Guid id);

        bool LoginUser(User user);
    }
}
