﻿using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Linq;

namespace BookReadingEvents.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly IUserData userData;

        public UserBusinessLogic() {
            this.userData = new DummyUserData();
        }

        public User GetUserById(Guid id)
        {
            var user = userData.GetUserById(id);
            return user;
        }
    
        public bool DoesUserExist(User user)
        {
            bool res = userData.DoesUserExist(user);
            return res;
        }

        public void AddUser(User user)
        {
            userData.AddUser(user);
        }

        public User GetUserByEmail(string email)
        {
            return userData.GetAll().FirstOrDefault(u => u.Email.Equals(email));
        }

     
    }
}
