using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using appweb.Models;

namespace appweb.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly AppDBContext _context;

        public DoctorsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Doctor.Include(d => d.Area).Include(d => d.Specialist);
            return View(await appDBContext.ToListAsync());
        }

        public IActionResult Register()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId");
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration([Bind("DoctorId,DoctorName,UserName,Password,PhoneNo,HospitalName,Address,Schedule,AreaId,SpecialistId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId", doctor.AreaId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId", doctor.SpecialistId);
            return View();
        }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Area)
                .Include(d => d.Specialist)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId");
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DoctorId,DoctorName,UserName,Password,PhoneNo,HospitalName,Address,Schedule,AreaId,SpecialistId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId", doctor.AreaId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId", doctor.SpecialistId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId", doctor.AreaId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId", doctor.SpecialistId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DoctorId,DoctorName,UserName,Password,PhoneNo,HospitalName,Address,Schedule,AreaId,SpecialistId")] Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.DoctorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Area, "AreaId", "AreaId", doctor.AreaId);
            ViewData["SpecialistId"] = new SelectList(_context.Specialist, "SpecialistId", "SpecialistId", doctor.SpecialistId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Area)
                .Include(d => d.Specialist)
                .FirstOrDefaultAsync(m => m.DoctorId == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.DoctorId == id);
        }
    }
}
