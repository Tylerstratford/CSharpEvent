using System;
using System.Collections.Generic;
using System.IO;

namespace ConferenceXUnitTests
{
    public class Registration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Role { get; set; }

        public Guid Id { get; set; } = Guid.NewGuid();

        string filePath = @"C:\Users\tyler\Desktop\CSharpEvent\CSharpEvent\TextFile\ListOfAttendees.txt";


        /// <summary>
        /// Adds item to list
        /// </summary>
        List<Registration> newRegistration = new List<Registration>();
        internal bool AddToList(Registration attendee)
        {
            newRegistration.Add(attendee);
            if (newRegistration != null)
            { 
            return true;
            } else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes item from list
        /// </summary>
        /// <param name="attendee"></param>
        /// <returns></returns>
        //BtnDelete_Click
        internal bool RemoveFromList(Registration attendee)
        {
            newRegistration.Remove(attendee);
            if (newRegistration == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 
        /// <summary>
        /// Creates text file if no file exists
        /// </summary>
        /// <param name="newRegistration"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        internal bool CreateTextFile(List<Registration> newRegistration, string filePath)
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(newRegistration);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}