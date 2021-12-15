using CSharpEvent.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSharpEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Text file location
        string filePath = @"C:\Users\tyler\Desktop\CSharpEvent\CSharpEvent\TextFile\ListOfAttendees.txt";

        //Used for binding in WPF. List did not work as intended - issues with deleting list from GUI
        ObservableCollection<Registration> Attendee = new ObservableCollection<Registration>();

        public MainWindow()
        {
            
            InitializeComponent();
            Task.FromResult(RetreiveAttendees());

        }

        /// <summary>
        /// Adds regristation data on submit to listview and text file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbEmail.Text) && !string.IsNullOrEmpty(tbRole.Text)) {
                
                Registration NewRegistration = new Registration { FirstName = tbFirstName.Text, LastName = tbLastName.Text, Email = tbEmail.Text, Role = tbRole.Text };
                tbFirstName.Text = "";
                tbLastName.Text = "";
                tbEmail.Text = "";
                tbRole.Text = "";
                string newAttendee = $"{NewRegistration.FirstName} {NewRegistration.LastName} {NewRegistration.Email} {NewRegistration.Role} {NewRegistration.Id}";

                Attendee.Add(NewRegistration);
                lvAttendees.ItemsSource = Attendee;
               
                //Writing data to text file upon submission (Submit button)
                if (!File.Exists(filePath)) {
                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.WriteLine(newAttendee);
                    }
                } else
                {
                    using (StreamWriter sw = File.AppendText(filePath))
                    {
                        sw.WriteLine(newAttendee);
                    }
                }
            }
        }

        //Retreives data from Text.file
        /// <summary>
        /// Retreives data (list) from Text.file. Seperates string into an array for indexing
        /// </summary>
        /// <returns></returns>
        public async Task RetreiveAttendees()
        {

            string line;
            //Read only
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(" ");
                    Attendee.Add(new Registration { FirstName = parts[0], LastName = parts[1], Email = parts[2], Role = parts[3], Id = new Guid(parts[4]) } );

                }
            }

           FetchWait();
        }

        //If the list count is above 0 in the text file, the list will appear in the Listview, otherwise nothing is written.
        //Needed to solve issue with loading list upon program execution
        /// <summary>
        /// Displaying to listview if attendee count > 0, solving loading issue upon program execution
        /// </summary>
        private void FetchWait()
        {
            if (Attendee.Count > 0)
            {
                lvAttendees.ItemsSource = Attendee;
            }
        }


        //Deletes object from Listview and (text file). Rewrites file "ListOfAttendees"
        /// <summary>
        /// Deletes object from Listview and text filen on click - Rewrites to file "ListOfAttendees"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (Registration)obj.DataContext;
            Attendee.Remove(item);
 
            //Creating a new list to store data of the attendees that are not deleted
            ObservableCollection<Registration> attendeeTemp = new ObservableCollection<Registration>();

            string line;
            //Read only
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(" ");
                    if (item.Id.ToString() != parts[4])
                    {
                        attendeeTemp.Add(new Registration { FirstName = parts[0], LastName = parts[1], Email = parts[2], Role = parts[3], Id = new Guid(parts[4]) });
                    }
                }
            }

            File.Delete(filePath);
            //Rewriting the stored data in atendeeTemp to the text file
            using (StreamWriter sw = File.CreateText(filePath))
            {
                foreach (var person in attendeeTemp)
                {
                    sw.WriteLine($"{person.FirstName} {person.LastName} {person.Email} {person.Role} {person.Id}");

                }
            }
        }

    }
}
