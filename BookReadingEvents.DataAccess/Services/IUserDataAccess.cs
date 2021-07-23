using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;

namespace BookReadingEvents.DataAccess.Services
{
    public interface IUserDataAccess
    {
        IEnumerable<User> GetAll();

        User GetUserById(Guid id);

        bool DoesUserExist(User user);

        void AddUser(User user);

        void UpdateUser(User user);

        User GetUserByEmail(string email);
    }
}
