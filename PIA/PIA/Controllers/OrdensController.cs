using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;

namespace PIA.Controllers
{
    public class OrdensController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public OrdensController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Ordens.Include(o => o.IdmetodopagNavigation).Include(o => o.IdusuarioNavigation);
            return View(await libreriaProyectoContext.ToListAsync());
        }

        // GET: Ordens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdmetodopagNavigation)
                .Include(o => o.IdusuarioNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // GET: Ordens/Create
        public IActionResult Create()
        {
            ViewData["Idmetodopag"] = new SelectList(_context.Cmetodopags, "Idmetpag", "Idmetpag");
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Ordens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idorden,Idusuario,Idmetodopag,Total,Fecha")] Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idmetodopag"] = new SelectList(_context.Cmetodopags, "Idmetpag", "Idmetpag", orden.Idmetodopag);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Id", "Id", orden.Idusuario);
            return View(orden);
        }

        // GET: Ordens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }
            ViewData["Idmetodopag"] = new SelectList(_context.Cmetodopags, "Idmetpag", "Idmetpag", orden.Idmetodopag);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Id", "Id", orden.Idusuario);
            return View(orden);
        }

        // POST: Ordens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idorden,Idusuario,Idmetodopag,Total,Fecha")] Orden orden)
        {
            if (id != orden.Idorden)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdenExists(orden.Idorden))
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
            ViewData["Idmetodopag"] = new SelectList(_context.Cmetodopags, "Idmetpag", "Idmetpag", orden.Idmetodopag);
            ViewData["Idusuario"] = new SelectList(_context.Usuarios, "Id", "Id", orden.Idusuario);
            return View(orden);
        }

        // GET: Ordens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ordens == null)
            {
                return NotFound();
            }

            var orden = await _context.Ordens
                .Include(o => o.IdmetodopagNavigation)
                .Include(o => o.IdusuarioNavigation)
                .FirstOrDefaultAsync(m => m.Idorden == id);
            if (orden == null)
            {
                return NotFound();
            }

            return View(orden);
        }

        // POST: Ordens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ordens == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Ordens'  is null.");
            }
            var orden = await _context.Ordens.FindAsync(id);
            if (orden != null)
            {
                _context.Ordens.Remove(orden);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdenExists(int id)
        {
          return _context.Ordens.Any(e => e.Idorden == id);
        }
    }
}
