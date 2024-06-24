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
    public class AlergiasController : Controller
    {
        private readonly PruebaContext _context;

        public AlergiasController(PruebaContext context)
        {
            _context = context;
        }

        // GET: Alergias
        public async Task<IActionResult> Index()
        {
            var pruebaContext = _context.Alergia.Include(a => a.HistorialMedico);
            return View(await pruebaContext.ToListAsync());
        }

        // GET: Alergias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia
                .Include(a => a.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alergia == null)
            {
                return NotFound();
            }

            return View(alergia);
        }

        // GET: Alergias/Create
        public IActionResult Create()
        {
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id");
            return View();
        }

        // POST: Alergias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Alergia alergia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alergia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", alergia.HistorialMedicoId);
            return View(alergia);
        }

        // GET: Alergias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia.FindAsync(id);
            if (alergia == null)
            {
                return NotFound();
            }
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", alergia.HistorialMedicoId);
            return View(alergia);
        }

        // POST: Alergias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,HistorialMedicoId")] Alergia alergia)
        {
            if (id != alergia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alergia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlergiaExists(alergia.Id))
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
            ViewData["HistorialMedicoId"] = new SelectList(_context.HistorialMedico, "Id", "Id", alergia.HistorialMedicoId);
            return View(alergia);
        }

        // GET: Alergias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alergia = await _context.Alergia
                .Include(a => a.HistorialMedico)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alergia == null)
            {
                return NotFound();
            }

            return View(alergia);
        }

        // POST: Alergias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alergia = await _context.Alergia.FindAsync(id);
            if (alergia != null)
            {
                _context.Alergia.Remove(alergia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlergiaExists(int id)
        {
            return _context.Alergia.Any(e => e.Id == id);
        }
    }
}
