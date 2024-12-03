using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetBookingSystem
{
    class Appointment
    {
        public string Pet { get; set; }
        public string Owner { get; set; }
        public string TimeSlot { get; set; }
        public int Duration { get; set; }
        public string VetName { get; set; }
    }
}
