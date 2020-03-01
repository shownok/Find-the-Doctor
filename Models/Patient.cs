using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appweb.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
