using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;

namespace PIA.Controllers
{
    [Authorize(Roles = "Admin")]

    public class OrdendetallesController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public OrdendetallesController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Ordendetalles
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Ordendetalles.Include(o => o.IdlibrosNavigation).Include(o => o.IdordenNavigation);
            return View(await libreriaProyectoContext.ToListAsync());
        }

        // GET: Ordendetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordendetalles == null)
            {
                return NotFound();
            }

            var ordendetalle = await _context.Ordendetalles
                .Include(o => o.IdlibrosNavigation)
                .Include(o => o.IdordenNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (ordendetalle == null)
            {
                return NotFound();
            }

            return View(ordendetalle);
        }

        // GET: Ordendetalles/Create
        public IActionResult Create()
        {
            ViewData["Idlibros"] = new SelectList(_context.Libros, "IdLibro", "IdLibro");
            ViewData["Idorden"] = new SelectList(_context.Ordens, "Idorden", "Idorden");
            return View();
        }

        // POST: Ordendetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idorden,Idlibros,Cantidad,Precio")] Ordendetalle ordendetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordendetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idlibros"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", ordendetalle.Idlibros);
            ViewData["Idorden"] = new SelectList(_context.Ordens, "Idorden", "Idorden", ordendetalle.Idorden);
            return View(ordendetalle);
        }

        // GET: Ordendetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordendetalles == null)
            {
                return NotFound();
            }

            var ordendetalle = await _context.Ordendetalles.FindAsync(id);
            if (ordendetalle == null)
            {
                return NotFound();
            }
            ViewData["Idlibros"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", ordendetalle.Idlibros);
            ViewData["Idorden"] = new SelectList(_context.Ordens, "Idorden", "Idorden", ordendetalle.Idorden);
            return View(ordendetalle);
        }

        // POST: Ordendetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idorden,Idlibros,Cantidad,Precio")] Ordendetalle ordendetalle)
        {
            if (id != ordendetalle.Idorden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordendetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdendetalleExists(ordendetalle.Idorden))
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
            ViewData["Idlibros"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", ordendetalle.Idlibros);
            ViewData["Idorden"] = new SelectList(_context.Ordens, "Idorden", "Idorden", ordendetalle.Idorden);
            return View(ordendetalle);
        }

        // GET: Ordendetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordendetalles == null)
            {
                return NotFound();
            }

            var ordendetalle = await _context.Ordendetalles
                .Include(o => o.IdlibrosNavigation)
                .Include(o => o.IdordenNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (ordendetalle == null)
            {
                return NotFound();
            }

            return View(ordendetalle);
        }

        // POST: Ordendetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordendetalles == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Ordendetalles'  is null.");
            }
            var ordendetalle = await _context.Ordendetalles.FindAsync(id);
            if (ordendetalle != null)
            {
                _context.Ordendetalles.Remove(ordendetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdendetalleExists(int id)
        {
          return _context.Ordendetalles.Any(e => e.Idorden == id);
        }
    }
}
