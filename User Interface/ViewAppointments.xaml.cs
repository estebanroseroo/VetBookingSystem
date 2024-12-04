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
using System.Windows.Shapes;
using VetBookingSystem.Database;

namespace VetBookingSystem.User_Interface
{

    public partial class ViewAppointments : Window
    {
        private BookingSystem bookingSystem;
        public ViewAppointments()
        {
            InitializeComponent();
            bookingSystem = new BookingSystem();
            LoadAppointments();
        }
        private void LoadAppointments()
        {
            Schedule schedule = bookingSystem.GetSchedule();
            var sortedAppointments = schedule.Appointments
                .OrderBy(a => TimeSpan.Parse(a.TimeSlot))
                .ToList();
            AppointmentsListView.ItemsSource = sortedAppointments;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
