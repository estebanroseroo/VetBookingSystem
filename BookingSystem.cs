using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetBookingSystem.Database;

namespace VetBookingSystem
{
    class BookingSystem
    {
        private Schedule schedule;
        private string filePath;

        public BookingSystem()
        {
            filePath = "\\Users\\Esteban\\Desktop\\Conestoga\\HQ\\second semester\\VetBookingSystem\\Database\\database.json";
            schedule = DatabaseLoader.LoadData(filePath);
        }

        public string BookAppointment(string owner, string pet, DateTime appointmentTime, int duration)
        {
            if (appointmentTime.Hour < 8 || appointmentTime.Hour >= 21)
            {
                return "Sorry, the vet's office is closed at that time.";
            }
            var availableVet = schedule.Vets.FirstOrDefault(vet => vet.IsAvailable(appointmentTime));
            if (availableVet == null)
            {
                return "Sorry, no vet is available at this time. Please choose another time.";
            }
            var availableTechnicians = schedule.Technicians.Where(t => IsTechnicianAvailable(appointmentTime, t)).ToList();
            if (availableTechnicians.Count < 2)
            {
                return "Sorry, there are not enough technicians available at this time.";
            }
            schedule.Appointments.Add(new Appointment
            {
                Pet = pet,
                Owner = owner,
                TimeSlot = appointmentTime.ToString("HH:mm"),
                Duration = duration,
                VetName = availableVet.Name
            });
            SaveScheduleToJson(filePath);
            return $"Appointment booked with {availableVet.Name} at {appointmentTime:HH:mm}.";
        }

        public Schedule GetSchedule()
        {
            return schedule;
        }

        private bool IsTechnicianAvailable(DateTime appointmentTime, Technician technician)
        {
            DateTime shiftStart = DateTime.Parse(technician.ShiftStart);
            DateTime shiftEnd = DateTime.Parse(technician.ShiftEnd);
            return appointmentTime >= shiftStart && appointmentTime <= shiftEnd;
        }
        private void SaveScheduleToJson(string filePath)
        {
            var json = JsonConvert.SerializeObject(schedule, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
