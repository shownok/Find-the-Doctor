using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appweb.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string TreatmentDetails { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
