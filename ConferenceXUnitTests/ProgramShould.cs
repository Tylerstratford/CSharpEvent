using System;
using System.Collections.Generic;
using Xunit;


namespace ConferenceXUnitTests
{
    public class ProgramShould
    {

        public Registration sut = new Registration();

        [Fact]
        public void Add_To_List()
        {
            //Arrange
            var attendee = new Registration() { FirstName = "Tyler", LastName = "Stratford", Email = "tylerstratford@hotmail.com", Role = "Attendee", Id = Guid.NewGuid() };
            //Act
            bool succeeded = sut.AddToList(attendee);
            //Assert
            Assert.True(succeeded);
        }

        [Fact]
        public void Create_Text_File()
        {
            //Arange
            string filePath = @"C:\Users\tyler\Desktop\CSharpEvent\CSharpEvent\TextFile\ListOfAttendees.txt";
            var newRegistration = new List<Registration>() { new Registration() { FirstName = "Tyler", LastName = "Stratford", Email = "tylerstratford@hotmail.com", Role = "Attendee", Id = Guid.NewGuid() } };
            //Act
            bool succeeded = sut.CreateTextFile(newRegistration, filePath);
            //Assert
            Assert.True(!succeeded);
        }
    }
}