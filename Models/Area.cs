using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appweb.Models
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; }
        public string PhoneNo { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}
