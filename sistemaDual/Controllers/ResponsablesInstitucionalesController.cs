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
    public class ResponsablesInstitucionalesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public ResponsablesInstitucionalesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: ResponsablesInstitucionales
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.ResponsablesInstitucionales.Include(r => r.Universidad);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: ResponsablesInstitucionales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ResponsablesInstitucionales == null)
            {
                return NotFound();
            }

            var responsableInstitucional = await _context.ResponsablesInstitucionales
                .Include(r => r.Universidad)
                .FirstOrDefaultAsync(m => m.ResponsableInstitucionalID == id);
            if (responsableInstitucional == null)
            {
                return NotFound();
            }

            return View(responsableInstitucional);
        }

        // GET: ResponsablesInstitucionales/Create
        public IActionResult Create()
        {
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID");
            return View();
        }

        // POST: ResponsablesInstitucionales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResponsableInstitucionalID,Nombre,ApellidoP,ApellidoM,Correo,Telefono,Cargo,UniversidadID")] ResponsableInstitucionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var responsableI = new ResponsableInstitucional()
                {
                    ResponsableInstitucionalID = model.ResposableInstitucionalID,
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    Correo = model.Correo,
                    Telefono = model.Telefono,
                    Cargo = model.Cargo,
                    UniversidadID = model.UniversidadID

                };
                _context.Add(responsableI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID", model.UniversidadID);
            return View(model);
        }

        // GET: ResponsablesInstitucionales/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ResponsablesInstitucionales == null)
            {
                return NotFound();
            }

            var responsableInstitucional = await _context.ResponsablesInstitucionales.FindAsync(id);
            if (responsableInstitucional == null)
            {
                return NotFound();
            }
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID", responsableInstitucional.UniversidadID);
            return View(responsableInstitucional);
        }

        // POST: ResponsablesInstitucionales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ResponsableInstitucionalID,Nombre,ApellidoP,ApellidoM,Correo,Telefono,Cargo,UniversidadID")] ResponsableInstitucional responsableInstitucional)
        {
            if (id != responsableInstitucional.ResponsableInstitucionalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsableInstitucional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsableInstitucionalExists(responsableInstitucional.ResponsableInstitucionalID))
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
            ViewData["UniversidadID"] = new SelectList(_context.Universidades, "UniversidadID", "UniversidadID", responsableInstitucional.UniversidadID);
            return View(responsableInstitucional);
        }

        // GET: ResponsablesInstitucionales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ResponsablesInstitucionales == null)
            {
                return NotFound();
            }

            var responsableInstitucional = await _context.ResponsablesInstitucionales
                .Include(r => r.Universidad)
                .FirstOrDefaultAsync(m => m.ResponsableInstitucionalID == id);
            if (responsableInstitucional == null)
            {
                return NotFound();
            }

            return View(responsableInstitucional);
        }

        // POST: ResponsablesInstitucionales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ResponsablesInstitucionales == null)
            {
                return Problem("Entity set 'ProgramaDualContext.ResponsablesInstitucionales'  is null.");
            }
            var responsableInstitucional = await _context.ResponsablesInstitucionales.FindAsync(id);
            if (responsableInstitucional != null)
            {
                _context.ResponsablesInstitucionales.Remove(responsableInstitucional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsableInstitucionalExists(string id)
        {
          return _context.ResponsablesInstitucionales.Any(e => e.ResponsableInstitucionalID == id);
        }
    }
}
