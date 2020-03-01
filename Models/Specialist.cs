using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appweb.Models
{
    public class Specialist
    {
        public int SpecialistId { get; set; }
        public string SpecialistType { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
