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

        //Used for binding in WPF
        ObservableCollection<Registration> attendee = new ObservableCollection<Registration>();

        public MainWindow()
        {
            
            InitializeComponent();
            Task.FromResult(RetreiveAttendees());

        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Registration NewRegistration = new Registration { FirstName = tbFirstName.Text, LastName = tbLastName.Text, Email = tbEmail.Text, Role = tbRole.Text  };
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            tbRole.Text = "";
            string newAttendee = $"{NewRegistration.FirstName} {NewRegistration.LastName} {NewRegistration.Email} {NewRegistration.Role} {NewRegistration.CouponCode}";
            
            attendee.Add(NewRegistration);
            lvAttendees.ItemsSource = attendee;

            //Writing data to text file
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

        //Retrieves data from Text.file
        public async Task RetreiveAttendees()
        {

            string line;
            //Read only
            using (StreamReader sr = new StreamReader(filePath))
            {
                while ((line = await sr.ReadLineAsync()) != null)
                {
                    string[] parts = line.Split(" ");
                    attendee.Add(new Registration { FirstName = parts[0], LastName = parts[1], Email = parts[2], Role = parts[3] } );

                }
            }

           await FetchWait();
        }

        //If the list count is above 0 in the text file, the list will appear in the Listview, otherwise nothing is written.
        //Needed to solve issue with loading list upon program execution
        private async Task FetchWait()
        {
            if (attendee.Count > 0)
            {
                lvAttendees.ItemsSource = attendee;
            }
        }


        //Deletes object from Listview and (text file)
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (Registration)obj.DataContext;
            attendee.Remove(item);
        }

        private void ShowCode_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
