using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using appweb.Models;

namespace appweb.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext (DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<appweb.Models.Area> Area { get; set; }

        public DbSet<appweb.Models.Specialist> Specialist { get; set; }

        public DbSet<appweb.Models.Doctor> Doctor { get; set; }

        public DbSet<appweb.Models.Patient> Patient { get; set; }

        public DbSet<appweb.Models.Appointment> Appointment { get; set; }
    }
}
