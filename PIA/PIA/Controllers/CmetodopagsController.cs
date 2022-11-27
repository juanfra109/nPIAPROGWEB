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

    public class CmetodopagsController : Controller
    {
        private readonly LibreriaProyectoContext _context;

        public CmetodopagsController(LibreriaProyectoContext context)
        {
            _context = context;
        }

        // GET: Cmetodopags
        public async Task<IActionResult> Index()
        {
              return View(await _context.Cmetodopags.ToListAsync());
        }

        // GET: Cmetodopags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cmetodopags == null)
            {
                return NotFound();
            }

            var cmetodopag = await _context.Cmetodopags
                .FirstOrDefaultAsync(m => m.Idmetpag == id);
            if (cmetodopag == null)
            {
                return NotFound();
            }

            return View(cmetodopag);
        }

        // GET: Cmetodopags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cmetodopags/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idmetpag,Descripcion")] Cmetodopag cmetodopag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cmetodopag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cmetodopag);
        }

        // GET: Cmetodopags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cmetodopags == null)
            {
                return NotFound();
            }

            var cmetodopag = await _context.Cmetodopags.FindAsync(id);
            if (cmetodopag == null)
            {
                return NotFound();
            }
            return View(cmetodopag);
        }

        // POST: Cmetodopags/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idmetpag,Descripcion")] Cmetodopag cmetodopag)
        {
            if (id != cmetodopag.Idmetpag)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cmetodopag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CmetodopagExists(cmetodopag.Idmetpag))
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
            return View(cmetodopag);
        }

        // GET: Cmetodopags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cmetodopags == null)
            {
                return NotFound();
            }

            var cmetodopag = await _context.Cmetodopags
                .FirstOrDefaultAsync(m => m.Idmetpag == id);
            if (cmetodopag == null)
            {
                return NotFound();
            }

            return View(cmetodopag);
        }

        // POST: Cmetodopags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cmetodopags == null)
            {
                return Problem("Entity set 'LibreriaProyectoContext.Cmetodopags'  is null.");
            }
            var cmetodopag = await _context.Cmetodopags.FindAsync(id);
            if (cmetodopag != null)
            {
                _context.Cmetodopags.Remove(cmetodopag);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CmetodopagExists(int id)
        {
          return _context.Cmetodopags.Any(e => e.Idmetpag == id);
        }
    }
}
