using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaMainSoft_2.Models;

namespace PruebaMainSoft_2.Controllers
{
    public class AutoresHasLibroesController : Controller
    {
        private readonly PruebaMainSoftContext _context;

        public AutoresHasLibroesController(PruebaMainSoftContext context)
        {
            _context = context;
        }

        // GET: AutoresHasLibroes
        public async Task<IActionResult> Index()
        {
            var pruebaMainSoftContext = _context.AutoresHasLibros.Include(a => a.Autores).Include(a => a.LibrosIs8nNavigation);
            return View(await pruebaMainSoftContext.ToListAsync());
        }

        // GET: AutoresHasLibroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresHasLibro = await _context.AutoresHasLibros
                .Include(a => a.Autores)
                .Include(a => a.LibrosIs8nNavigation)
                .FirstOrDefaultAsync(m => m.AutoresId == id);
            if (autoresHasLibro == null)
            {
                return NotFound();
            }

            return View(autoresHasLibro);
        }

        // GET: AutoresHasLibroes/Create
        public IActionResult Create()
        {
            ViewData["AutoresId"] = new SelectList(_context.Autores, "Id", "Apellido");
            ViewData["LibrosIs8n"] = new SelectList(_context.Libros, "Is8n", "Titulo");
            return View();
        }

        // POST: AutoresHasLibroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoresId,LibrosIs8n")] AutoresHasLibro autoresHasLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoresHasLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoresId"] = new SelectList(_context.Autores, "Id", "Apellido", autoresHasLibro.AutoresId);
            ViewData["LibrosIs8n"] = new SelectList(_context.Libros, "Is8n", "Titulo", autoresHasLibro.LibrosIs8n);
            return View(autoresHasLibro);
        }

        // GET: AutoresHasLibroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresHasLibro = await _context.AutoresHasLibros.FindAsync(id);
            if (autoresHasLibro == null)
            {
                return NotFound();
            }
            ViewData["AutoresId"] = new SelectList(_context.Autores, "Id", "Apellido", autoresHasLibro.AutoresId);
            ViewData["LibrosIs8n"] = new SelectList(_context.Libros, "Is8n", "Titulo", autoresHasLibro.LibrosIs8n);
            return View(autoresHasLibro);
        }

        // POST: AutoresHasLibroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoresId,LibrosIs8n")] AutoresHasLibro autoresHasLibro)
        {
            if (id != autoresHasLibro.AutoresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoresHasLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoresHasLibroExists(autoresHasLibro.AutoresId))
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
            ViewData["AutoresId"] = new SelectList(_context.Autores, "Id", "Apellido", autoresHasLibro.AutoresId);
            ViewData["LibrosIs8n"] = new SelectList(_context.Libros, "Is8n", "Titulo", autoresHasLibro.LibrosIs8n);
            return View(autoresHasLibro);
        }

        // GET: AutoresHasLibroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var autoresHasLibro = await _context.AutoresHasLibros
                .Include(a => a.Autores)
                .Include(a => a.LibrosIs8nNavigation)
                .FirstOrDefaultAsync(m => m.AutoresId == id);
            if (autoresHasLibro == null)
            {
                return NotFound();
            }

            return View(autoresHasLibro);
        }

        // POST: AutoresHasLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var autoresHasLibro = await _context.AutoresHasLibros.FindAsync(id);
            _context.AutoresHasLibros.Remove(autoresHasLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoresHasLibroExists(int id)
        {
            return _context.AutoresHasLibros.Any(e => e.AutoresId == id);
        }
    }
}
