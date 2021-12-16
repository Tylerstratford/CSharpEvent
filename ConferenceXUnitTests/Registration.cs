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

        internal bool RemoveFromList(Registration attendee)
        {
            newRegistration.Remove(attendee);
            if (newRegistration != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

 
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
            //if (File.Exists(filePath))
            //{
            //    using (StreamWriter sw = File.AppendText(filePath))
            //    {
            //        sw.WriteLine(newRegistration);
            //    }
            //    return true;
            //} 
            //else { return false; }
        }
        
    }
}