using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Models;
using sistemaDual.Models.ViewModels;

namespace sistemaDual.Controllers
{
    public class ProgramasEducativosController : Controller
    {
        private readonly ProgramaDualContext _context;

        public ProgramasEducativosController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: ProgramaEducativoes
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.ProgramasEducativos.Include(p => p.Universidad);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: ProgramaEducativoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProgramasEducativos == null)
            {
                return NotFound();
            }

            var programaEducativo = await _context.ProgramasEducativos
                .Include(p => p.Universidad)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programaEducativo == null)
            {
                return NotFound();
            }

            return View(programaEducativo);
        }

        // GET: ProgramaEducativoes/Create
        public IActionResult Create()
        {
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID");
            return View();
        }

        // POST: ProgramaEducativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Version,UniversidadID")] ProgramaEducativoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var programaE = new ProgramaEducativo()
                {
                    Nombre = model.Nombre,
                    Version = model.Version,
                    UniversidadID = model.UniversidadID
                };
                _context.Add(programaE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        // GET: ProgramaEducativoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProgramasEducativos == null)
            {
                return NotFound();
            }

            var programaEducativo = await _context.ProgramasEducativos.FindAsync(id);
            if (programaEducativo == null)
            {
                return NotFound();
            }
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID", programaEducativo.UniversidadID);
            return View(programaEducativo);
        }

        // POST: ProgramaEducativoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Version,UniversidadID")] ProgramaEducativo programaEducativo)
        {
            if (id != programaEducativo.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programaEducativo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramaEducativoExists(programaEducativo.ID))
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
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID", programaEducativo.UniversidadID);
            return View(programaEducativo);
        }

        // GET: ProgramaEducativoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProgramasEducativos == null)
            {
                return NotFound();
            }

            var programaEducativo = await _context.ProgramasEducativos
                .Include(p => p.Universidad)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (programaEducativo == null)
            {
                return NotFound();
            }

            return View(programaEducativo);
        }

        // POST: ProgramaEducativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProgramasEducativos == null)
            {
                return Problem("Entity set 'ProgramaDualContext.ProgramasEducativos'  is null.");
            }
            var programaEducativo = await _context.ProgramasEducativos.FindAsync(id);
            if (programaEducativo != null)
            {
                _context.ProgramasEducativos.Remove(programaEducativo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramaEducativoExists(int id)
        {
          return _context.ProgramasEducativos.Any(e => e.ID == id);
        }
    }
}
