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
    public class SpecialistsController : Controller
    {
        private readonly AppDBContext _context;

        public SpecialistsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: Specialists
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specialist.ToListAsync());
        }

        // GET: Specialists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .FirstOrDefaultAsync(m => m.SpecialistId == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // GET: Specialists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Specialists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecialistId,SpecialistType")] Specialist specialist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specialist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specialist);
        }

        // GET: Specialists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist.FindAsync(id);
            if (specialist == null)
            {
                return NotFound();
            }
            return View(specialist);
        }

        // POST: Specialists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecialistId,SpecialistType")] Specialist specialist)
        {
            if (id != specialist.SpecialistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specialist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecialistExists(specialist.SpecialistId))
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
            return View(specialist);
        }

        // GET: Specialists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specialist = await _context.Specialist
                .FirstOrDefaultAsync(m => m.SpecialistId == id);
            if (specialist == null)
            {
                return NotFound();
            }

            return View(specialist);
        }

        // POST: Specialists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specialist = await _context.Specialist.FindAsync(id);
            _context.Specialist.Remove(specialist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecialistExists(int id)
        {
            return _context.Specialist.Any(e => e.SpecialistId == id);
        }
    }
}
