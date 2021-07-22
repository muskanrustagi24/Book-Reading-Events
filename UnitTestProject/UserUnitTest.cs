using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;

namespace UnitTestProject
{
    public class UserUnitTest
    {

        [Theory]
        [InlineData]
        public void TestMethod1(Mock<IUserData> userData, EventBusinessLogic sut)
        {
            //Arrange
            User expectedUser = new User
            {
                Email = "abc@gmail.com",
                Password = "12345678",
                Role = UserType.Normal
            };

            userData.Setup(ed => ed.GetUserByEmail(It.IsAny<string>())).Returns(expectedUser);

            string emailId = "abc@gmail.com";

            //Act
            UserBusinessLogic user = new UserBusinessLogic();
            User actualUser = user.GetUserByEmail(emailId);

            //Assert
            Assert.AreEqual(expectedUser, actualUser);
        }


        [Theory]
        [InlineData]
        public void TestMethod2(Mock<IUserData> userData, EventBusinessLogic sut)
        {
            //Arrange
            bool expectedResult = true;

            userData.Setup(ed => ed.DoesUserExist(It.IsAny<User>())).Returns(expectedResult);

            User checkUser = new User
            {
                Email = "abc@gmail.com",
                Password = "12345678",
                Role = UserType.Normal
            };

            //Act
            UserBusinessLogic user = new UserBusinessLogic();
            bool actualResult = user.DoesUserExist(checkUser);

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
