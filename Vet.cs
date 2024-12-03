using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetBookingSystem
{
    class Vet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShiftStart { get; set; }
        public string ShiftEnd { get; set; }
        public int WorkedHours { get; set; }

        public bool IsAvailable(DateTime appointmentTime)
        {
            DateTime shiftStart = DateTime.Parse(ShiftStart);
            DateTime shiftEnd = DateTime.Parse(ShiftEnd);
            return appointmentTime >= shiftStart && appointmentTime <= shiftEnd;
        }
    }
}
