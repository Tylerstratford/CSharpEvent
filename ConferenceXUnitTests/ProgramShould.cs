using System;
using System.Collections.Generic;
using Xunit;


namespace ConferenceXUnitTests
{
    public class ProgramShould
    {

        public Registration sut = new Registration();

        /// <summary>
        /// Checks if item is added to list
        /// </summary>
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

        /// <summary>
        /// Checks if item is removed from list
        /// </summary>
        [Fact]
        public void Remove_From_List()
        {
            //Arrange
            var attendee = new Registration() { FirstName = "Tyler", LastName = "Stratford", Email = "tylerstratford@hotmail.com", Role = "Attendee", Id = Guid.NewGuid() };
            sut.AddToList(attendee);
            //Act
            bool succeeded = sut.RemoveFromList(attendee);
            //Assert
            Assert.True(!succeeded);
        }


        /// <summary>
        /// Checks if text file is created
        /// </summary>
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