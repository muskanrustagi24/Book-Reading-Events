using BookReadingEvents.BusinessLogic;
using BookReadingEvents.DataAccess.Services;
using BookReadingEvents.Domain;
using BookReadingEvents.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit;

namespace UnitTestProject
{
    public class EventUnitTest
    {
        [Theory]
        [InlineData]
        public void TestMethod1(Mock<IEventDataAccess> eventData, EventBusinessLogic sut)
        {
            //Arrange
            Event expectedEvent = new Event {
                Title = "Event 1",
                Date = new DateTime(2021, 07, 31),
                Description = "abc",
                Duration = 3,
                Location = "Noida",
                TypeOfEvent = EventType.Public,
                OtherDetails = "abc"
            };

            eventData.Setup(ed => ed.GetEventByEventId(It.IsAny<Guid>())).Returns(expectedEvent);

            Guid eventId = new Guid("83153008 - 2cea - eb11 - b7a3 - 7478278301b4");

            //Act
            EventBusinessLogic _event = new EventBusinessLogic();
            Event actualEvent = _event.GetEventByEventId(eventId);

            //Assert
            Assert.AreEqual(expectedEvent, actualEvent);
        }
    }
}
