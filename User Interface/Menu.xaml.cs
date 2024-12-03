using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VetBookingSystem.Database;
using VetBookingSystem.User_Interface;

namespace VetBookingSystem
{
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            displayGreeting();
        }

        public void displayGreeting()
        {
            Greeting.Text = $"Welcome to the Vet's Office Booking System";
        }

        public void BookAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            BookAppointment appointment = new BookAppointment();
            appointment.Show();
            this.Close();
        }

        public void ViewAppointmentsButton_Click(object sender, RoutedEventArgs e)
        {
            ViewAppointments appointment = new ViewAppointments();
            appointment.Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}