using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class MedicacionsController : Controller
    {
        private readonly PruebaContext _context;

        public MedicacionsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Medicacions
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Medicacion.Include(m => m.HistorialMedico);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: Medicacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicacion = await _context.Medicacion
                .Include(m => m.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicacion == null)
            {
                return NotFound();
            }

            return View(medicacion);
        }

        // GET: Medicacions/Create
        public IActionResult Create()
        {
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id");
            return View();
        }

        // POST: Medicacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Medicacion medicacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", medicacion.HistorialMedicoId);
            return View(medicacion);
        }

        // GET: Medicacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicacion = await _context.Medicacion.FindAsync(id);
            if (medicacion == null)
            {
                return NotFound();
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", medicacion.HistorialMedicoId);
            return View(medicacion);
        }

        // POST: Medicacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Medicacion medicacion)
        {
            if (id != medicacion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicacionExists(medicacion.Id))
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
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", medicacion.HistorialMedicoId);
            return View(medicacion);
        }

        // GET: Medicacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medicacion = await _context.Medicacion
                .Include(m => m.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicacion == null)
            {
                return NotFound();
            }

            return View(medicacion);
        }

        // POST: Medicacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medicacion = await _context.Medicacion.FindAsync(id);
            if (medicacion != null)
            {
                _context.Medicacion.Remove(medicacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicacionExists(int id)
        {
            return _context.Medicacion.Any(e => e.Id == id);
        }
    }
}
