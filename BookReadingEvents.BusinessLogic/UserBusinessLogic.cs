using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;

namespace BookReadingEvents.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly IUserData userData;

        public UserBusinessLogic() {
            userData = new DummyUserData();
        }

        public void SignUpUser(User user) {
            userData.AddUser(user);
        }

        public bool IsUserValid(User user) {
            bool result = userData.DoesUserExist(user);
            return result;
        }

        public User GetUserByUserId(Guid userId) {
            var user = userData.GetUserById(userId);
            return user;
        }

        public User GetUserByEmail(string email) {
            var user = userData.GetUserByEmail(email);
            return user;
        }

    }
}
