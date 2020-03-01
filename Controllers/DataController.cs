using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace appweb.Controllers
{
    public class DataController : Controller
    {
        private readonly AppDBContext _context;

        public DataController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var arealist = _context.Area.OrderBy(d => d.AreaName);
            ViewBag.area = arealist;
            var specialist = _context.Specialist.OrderBy(d => d.SpecialistType);
            ViewBag.special = specialist;
            return View();
        }

        public JsonResult GetDoctor(int id1, int id2)
        {
            var doctorlist = _context.Doctor.Where(d => d.AreaId == id1 && d.SpecialistId == id2).OrderBy(d => d.DoctorName);
            return Json(doctorlist.ToList());
        }

        public JsonResult GetDoctor2(int id3)
        {
            var doctorlist2 = _context.Doctor.Where(d => d.DoctorId == id3);
            return Json(doctorlist2.ToList());
        }


    }
}