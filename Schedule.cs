using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetBookingSystem
{
    class Schedule
    {
        public List<Vet> Vets { get; set; }
        public List<Technician> Technicians { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
