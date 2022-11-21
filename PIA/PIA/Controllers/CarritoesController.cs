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
    public class CarritoesController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public CarritoesController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Carritoes
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Carritos.Include(c => c.IdLibroNavigation).Include(c => c.IdUsuarioNavigation);
            return View(await libreriaProyectoContext.ToListAsync());
        }

        // GET: Carritoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.IdLibroNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // GET: Carritoes/Create
        public IActionResult Create()
        {
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Carritoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,IdLibro,Cantidad,Total")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carrito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", carrito.IdLibro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", carrito.IdUsuario);
            return View(carrito);
        }

        // GET: Carritoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", carrito.IdLibro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", carrito.IdUsuario);
            return View(carrito);
        }

        // POST: Carritoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,IdLibro,Cantidad,Total")] Carrito carrito)
        {
            if (id != carrito.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carrito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarritoExists(carrito.IdUsuario))
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
            ViewData["IdLibro"] = new SelectList(_context.Libros, "IdLibro", "IdLibro", carrito.IdLibro);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id", "Id", carrito.IdUsuario);
            return View(carrito);
        }

        // GET: Carritoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carritos == null)
            {
                return NotFound();
            }

            var carrito = await _context.Carritos
                .Include(c => c.IdLibroNavigation)
                .Include(c => c.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (carrito == null)
            {
                return NotFound();
            }

            return View(carrito);
        }

        // POST: Carritoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carritos == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Carritos'  is null.");
            }
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarritoExists(int id)
        {
          return _context.Carritos.Any(e => e.IdUsuario == id);
        }
    }
}
