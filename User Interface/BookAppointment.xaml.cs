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
    public partial class BookAppointment : Window
    {
        private BookingSystem bookingSystem;

        public BookAppointment()
        {
            InitializeComponent();
            bookingSystem = new BookingSystem();
            PopulateTimeComboBox();
        }

        private void PopulateTimeComboBox()
        {
            TimeSpan startTime = new TimeSpan(8, 0, 0);
            TimeSpan endTime = new TimeSpan(20, 40, 0);
            TimeSpan increment = new TimeSpan(0, 20, 0);
            Schedule schedule = bookingSystem.GetSchedule();
            var slots = schedule.Appointments.Select(a => a.TimeSlot).ToHashSet();
            TimeComboBox.Items.Clear();
            for (TimeSpan time = startTime; time <= endTime; time += increment)
            {
                string slot = time.ToString(@"hh\:mm");
                if (!slots.Contains(slot))
                {
                    TimeComboBox.Items.Add(slot);
                }
            }
            if (TimeComboBox.Items.Count > 0)
            {
                TimeComboBox.SelectedIndex = 0;
            }
        }

        private void BookAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime requestedTime;
            string selectedTime = TimeComboBox.SelectedItem.ToString();
            if (DateTime.TryParse(selectedTime, out requestedTime))
            {
                string pet = PetTextBox.Text;
                string owner = OwnerTextBox.Text;
                string result = bookingSystem.BookAppointment(owner, pet, requestedTime, 20);
                MessageBox.Show(result);
                if (!result.Contains("Sorry"))
                {
                    var menu = new Menu();
                    menu.Show();
                    this.Close();
                } 
            }
            else
            {
                MessageBox.Show("Invalid time format.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var menu = new Menu();
            menu.Show();
            this.Close();
        }
    }
}
