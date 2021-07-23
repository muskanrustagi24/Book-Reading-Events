using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using System;
using System.Linq;

namespace BookReadingEvents.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly IUserDataAccess userData;

        public UserBusinessLogic() {
            this.userData = new UserDataAccess();
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

        public User IsUserVerified(string email , string password) {
           var user = userData.GetAll().FirstOrDefault(u => u.Email.Equals(email) && u.Password.Equals(password));
           return user;
        }

        public int LoginVerifications(User user) {
            int flag = -1;
            var verfiedUser = GetUserByEmail(user.Email);

            if (verfiedUser != null && verfiedUser.Password.Equals(user.Password))
            {
                if (verfiedUser.Role == Domain.Enums.UserType.Admin)
                {
                    flag = 1;
                }
                else
                {
                    flag = 0;
                }

            }

            return flag;
        }

        public int SignUpVerifications(User user) 
        {
            int flag;
           
            if (user.Email.Equals("admin@gmail.com"))
            {
                user.Role = Domain.Enums.UserType.Admin;
                flag = 1;
            }
            else{
                user.Role = Domain.Enums.UserType.Normal;
                flag = 0;
            }

            var userWithSameEmail = GetUserByEmail(user.Email);

            if (userWithSameEmail != null)
            {
                flag = -1;
            }
            

            return flag;
         
        }
    }
}
