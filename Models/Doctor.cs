using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appweb.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string Schedule { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
        
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
