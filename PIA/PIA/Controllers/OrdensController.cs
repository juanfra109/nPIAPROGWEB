using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Models.dbModels;

namespace PIA.Controllers
{

    public class OrdensController : Controller
    {
        private readonly LibreriaProyectoContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public OrdensController(LibreriaProyectoContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Ordens
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Ordens
                .Include(o => o.IdmetodopagNavigation).Include(o => o.IdusuarioNavigation)
                .Where(c => _signInManager.IsSignedIn(User) && c.IdusuarioNavigation.UserName == User.Identity.Name);

            return View(await libreriaProyectoContext.ToListAsync());
        }

        // GET: Ordens/Admin
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Admin()
        {
            var libreriaProyectoContext = _context.Ordens
                .Include(o => o.IdmetodopagNavigation)
                .Include(o => o.IdusuarioNavigation);

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
                .Include(o => o.Ordendetalles).ThenInclude(d => d.IdlibrosNavigation)
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

        [HttpGet]
        public async Task<IActionResult> OrdenCreadaConExito(int id)
        {
            var usuarioFirmado = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (usuarioFirmado == null) return Unauthorized();

            var orden = await _context.Ordens
                .Include(o => o.Ordendetalles).ThenInclude(d => d.IdlibrosNavigation)
                .FirstOrDefaultAsync(o => o.Idorden == id && o.Idusuario == usuarioFirmado.Id);

            if (orden == null) return NotFound();

            return View(orden);
        }

        [HttpPost]
        public async Task<IActionResult> CrearOrden(int metodoPago)
        {
            var usuarioFirmado = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (usuarioFirmado == null) return Unauthorized();

            var carrito = _context.Carritos.Where(c => c.IdUsuario == usuarioFirmado.Id);

            if (!carrito.Any()) return Conflict("El carrito no debe estar vacio.");

            var orden = new Orden
            {
                Idusuario = usuarioFirmado.Id,
                Idmetodopag = metodoPago,
                Fecha = DateTime.Now
            };

            foreach (var item in carrito)
            {
                var detalle = new Ordendetalle
                {
                    Idlibros = item.IdLibro,
                    Cantidad = item.Cantidad,
                    Precio = item.Total
                };

                orden.Ordendetalles.Add(detalle);
            }

            orden.Total = orden.Ordendetalles.Sum(d => d.Precio);

            var carritoPorEliminar = _context.Carritos.Where(c => c.IdUsuario == usuarioFirmado.Id);

            _context.Carritos.RemoveRange(carritoPorEliminar);

            await _context.Ordens.AddAsync(orden);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(OrdenCreadaConExito), new { id = orden.Idorden });
        }

        private bool OrdenExists(int id)
        {
          return _context.Ordens.Any(e => e.Idorden == id);
        }
    }
}
