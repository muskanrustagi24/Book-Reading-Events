using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReadingEvents.DataAccess.Services
{
    public class DummyUserData : IUserDataAccess
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

        public User GetUserById(Guid id)
        {
            var user = users.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        public bool DoesUserExist(User user)
        {
            var loginUser = users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            return loginUser != null;
        }

        public void AddUser(User user)
        {
            this.users = users.Append(user);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
