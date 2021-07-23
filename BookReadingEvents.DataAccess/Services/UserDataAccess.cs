using BookReadingEvents.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly BookReadingEventsDbContext userData;

        public UserDataAccess()
        {
            this.userData = new BookReadingEventsDbContext();
        }

        public void AddUser(User user)
        {
            userData.Users.Add(user);
            userData.SaveChanges();
        }

        public bool DoesUserExist(User user)
        {
            var loginUser = userData.Users.FirstOrDefault(u => (u.Email.Equals(user.Email) && u.Password.Equals(user.Password)));
            return loginUser != null;
        }

        public IEnumerable<User> GetAll()
        {
            return userData.Users.OrderBy(u => u.UserId);
        }

        public User GetUserByEmail(string email)
        {
            return userData.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public User GetUserById(Guid id)
        {
            return userData.Users.FirstOrDefault(u => u.UserId == id);
        }

        public void UpdateUser(User user)
        {
            var entry = userData.Entry(user);
            entry.State = EntityState.Modified;
            userData.SaveChanges();
        }
    }
}
