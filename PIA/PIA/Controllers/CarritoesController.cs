using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Models;
using PIA.Models.dbModels;

namespace PIA.Controllers
{
    [Authorize]
    public class CarritoesController : Controller
    {
        private readonly LibreriaProyectoContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CarritoesController(LibreriaProyectoContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        // GET: Carritoes
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Carritos.Include(c => c.IdLibroNavigation).Include(c => c.IdUsuarioNavigation)
                .Where(c => _signInManager.IsSignedIn(User) && c.IdUsuarioNavigation.UserName == User.Identity.Name);

            var metodosDePago = new SelectList(_context.Cmetodopags, "Idmetpag", "Descripcion");
            ViewBag.MetodosPago = metodosDePago;

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
        [HttpGet, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int libroId)
        {
            var usuarioFirmado = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (usuarioFirmado == null) return Unauthorized();

            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.IdUsuario == usuarioFirmado.Id && c.IdLibro == libroId);

            if (carrito != null)
            {
                _context.Carritos.Remove(carrito);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AgregarLibroAlCarrito(ModeloEntradaAgregarLibroAlCarrito modelo)
        {
            var usuarioFirmado = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            if (usuarioFirmado == null) return Unauthorized();

            var producto = await _context.Libros.FirstOrDefaultAsync(l => l.IdLibro == modelo.LibroId);
            if (producto == null) return Conflict("El libro no existe o ya no esta disponible.");

            var carrito = await _context.Carritos.FirstOrDefaultAsync(c => c.IdUsuario == usuarioFirmado.Id && c.IdLibro == producto.IdLibro);
            if (carrito == null)
            {
                await _context.Carritos.AddAsync(new Carrito
                {
                    IdUsuario = usuarioFirmado.Id,
                    IdLibro = modelo.LibroId,
                    Cantidad = modelo.Cantidad,
                    Total = producto.Precio * modelo.Cantidad
                });
            } else
            {
                carrito.Cantidad += modelo.Cantidad;
                carrito.Total = carrito.Cantidad * producto.Precio;
            }
            
            await _context.SaveChangesAsync();

            return Ok("El libro se agrego al carrito satisfactoriamente.");
        }

        private bool CarritoExists(int id)
        {
          return _context.Carritos.Any(e => e.IdUsuario == id);
        }
    }
}
