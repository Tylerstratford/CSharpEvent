using CSharpEvent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var item = new Registration { FirstName = tbFirstName.Text, LastName = tbLastName.Text, Age = tbAge.Text, Email = tbEmail.Text, Role = tbRole.Text  };
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbAge.Text = "";
            tbEmail.Text = "";
            tbRole.Text = "";
            lvAttendees.Items.Add(item);

        }

        private void btnDelete_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            lvAttendees.Items.Remove(tbRole);
        }
    }
}
