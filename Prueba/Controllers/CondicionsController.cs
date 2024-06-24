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
    public class CondicionsController : Controller
    {
        private readonly PruebaContext _context;

        public CondicionsController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Condicions
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Condicion.Include(c => c.HistorialMedico);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: Condicions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condicion
                .Include(c => c.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condicion == null)
            {
                return NotFound();
            }

            return View(condicion);
        }

        // GET: Condicions/Create
        public IActionResult Create()
        {
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id");
            return View();
        }

        // POST: Condicions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Condicion condicion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condicion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", condicion.HistorialMedicoId);
            return View(condicion);
        }

        // GET: Condicions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condicion.FindAsync(id);
            if (condicion == null)
            {
                return NotFound();
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", condicion.HistorialMedicoId);
            return View(condicion);
        }

        // POST: Condicions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Condicion condicion)
        {
            if (id != condicion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condicion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondicionExists(condicion.Id))
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
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", condicion.HistorialMedicoId);
            return View(condicion);
        }

        // GET: Condicions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condicion = await _context.Condicion
                .Include(c => c.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condicion == null)
            {
                return NotFound();
            }

            return View(condicion);
        }

        // POST: Condicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condicion = await _context.Condicion.FindAsync(id);
            if (condicion != null)
            {
                _context.Condicion.Remove(condicion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondicionExists(int id)
        {
            return _context.Condicion.Any(e => e.Id == id);
        }
    }
}
