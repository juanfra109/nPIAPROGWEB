using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PIA.Dto;
using PIA.Models.dbModels;

namespace PIA.Controllers
{
    public class LibroesController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public LibroesController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            var libreriaProyectoContext = _context.Libros.Include(l => l.AutorNavigation).Include(l => l.CategoriaNavigation).Include(l => l.EditorialNavigation);
            return View(await libreriaProyectoContext.ToListAsync());
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutorNavigation)
                .Include(l => l.CategoriaNavigation)
                .Include(l => l.EditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            ViewData["Autor"] = new SelectList(_context.Autores, "IdAutor", "Nombre");
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripción");
            ViewData["Editorial"] = new SelectList(_context.Editoriales, "Ideditorial", "Nombre");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( LibroCreateDto libro)
        {
            if (ModelState.IsValid)
            {
                Libro libronu = new Libro();
                libronu.Autor = libro.Autor;
                libronu.Categoria = libro.Categoria;
                libronu.Editorial = libro.Editorial;  
                libronu.Nombre = libro.Nombre;
                libronu.Precio = libro.Precio;
                libronu.Imagen = libro.Imagen;
                libronu.Añopublicacion = libro.Añopublicacion;
                libronu.Descripcion = libro.Descripcion;
                _context.Add(libronu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Autor"] = new SelectList(_context.Autores, "IdAutor", "Nombre", libro.Autor);
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripción", libro.Categoria);
            ViewData["Editorial"] = new SelectList(_context.Editoriales, "Ideditorial", "Nombre", libro.Editorial);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["Autor"] = new SelectList(_context.Autores, "IdAutor", "Nombre", libro.Autor);
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripción", libro.Categoria);
            ViewData["Editorial"] = new SelectList(_context.Editoriales, "Ideditorial", "Nombre", libro.Editorial);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Libro libro, LibroUpdateDto Libro)
        {
            if (id != Libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                try
                {
                    Libro libroup = new Libro();
                    libroup.Autor = Libro.Autor;
                    libroup.Categoria = Libro.Categoria;
                    libroup.Editorial = Libro.Editorial;
                    libroup.Nombre = Libro.Nombre;
                    libroup.Precio = Libro.Precio;
                    libroup.Imagen = Libro.Imagen;
                    libroup.Añopublicacion = Libro.Añopublicacion;
                    libroup.Descripcion = Libro.Descripcion;
                    libroup.IdLibro = Libro.IdLibro;
                    _context.Update(libroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(Libro.IdLibro))
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
            ViewData["Autor"] = new SelectList(_context.Autores, "IdAutor", "Nombre", Libro.Autor);
            ViewData["Categoria"] = new SelectList(_context.Categorias, "IdCategoria", "Descripción", Libro.Categoria);
            ViewData["Editorial"] = new SelectList(_context.Editoriales, "Ideditorial", "Nombre", Libro.Editorial);
            return View(Libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Libros == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.AutorNavigation)
                .Include(l => l.CategoriaNavigation)
                .Include(l => l.EditorialNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Libros == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Libros'  is null.");
            }
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
          return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
