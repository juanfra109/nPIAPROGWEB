using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;
using System.Globalization;


namespace PIA.Controllers
{
    [Authorize(Roles = "Admin")]

    public class SugerenciasController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public SugerenciasController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Sugerencias
        public async Task<IActionResult> Index()
        {
              return View(await _context.Sugerencias.ToListAsync());
        }

        // GET: Sugerencias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sugerencias == null)
            {
                return NotFound();
            }

            var sugerencia = await _context.Sugerencias
                .FirstOrDefaultAsync(m => m.Idsugerencia == id);
            if (sugerencia == null)
            {
                return NotFound();
            }

            return View(sugerencia);
        }

        // GET: Sugerencias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sugerencias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsugerencia,Descripcion,Fecha")] Sugerencia sugerencia)
        {
            if (ModelState.IsValid)
            {
                sugerencia.Fecha = DateTime.Now;
                _context.Add(sugerencia);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(sugerencia);
        }

        // GET: Sugerencias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sugerencias == null)
            {
                return NotFound();
            }

            var sugerencia = await _context.Sugerencias.FindAsync(id);
            if (sugerencia == null)
            {
                return NotFound();
            }
            return View(sugerencia);
        }

        // POST: Sugerencias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsugerencia,Descripcion,Fecha")] Sugerencia sugerencia)
        {
            if (id != sugerencia.Idsugerencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sugerencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SugerenciaExists(sugerencia.Idsugerencia))
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
            return View(sugerencia);
        }

        // GET: Sugerencias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sugerencias == null)
            {
                return NotFound();
            }

            var sugerencia = await _context.Sugerencias
                .FirstOrDefaultAsync(m => m.Idsugerencia == id);
            if (sugerencia == null)
            {
                return NotFound();
            }

            return View(sugerencia);
        }

        // POST: Sugerencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sugerencias == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Sugerencias'  is null.");
            }
            var sugerencia = await _context.Sugerencias.FindAsync(id);
            if (sugerencia != null)
            {
                _context.Sugerencias.Remove(sugerencia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SugerenciaExists(int id)
        {
          return _context.Sugerencias.Any(e => e.Idsugerencia == id);
        }
    }
}
