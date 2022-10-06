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
    public class AsesoresInstitucionalesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public AsesoresInstitucionalesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: AsesorInstitucionals
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.AsesoresInstitucionales.Include(a => a.ProgramaEducativo);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: AsesorInstitucionals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AsesoresInstitucionales == null)
            {
                return NotFound();
            }

            var asesorInstitucional = await _context.AsesoresInstitucionales
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.AsesorInstitucionalID == id);
            if (asesorInstitucional == null)
            {
                return NotFound();
            }

            return View(asesorInstitucional);
        }

        // GET: AsesorInstitucionals/Create
        public IActionResult Create()
        {
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre");
            return View();
        }

        // POST: AsesorInstitucionals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AsesorInstitucionalID,Nombre,ApellidoP,ApellidoM,ProgramaEducativoID")] AsesorInstitucionalViewModel model)
        {
            if (ModelState.IsValid)
            {
                var asesorI = new AsesorInstitucional()
                {
                    AsesorInstitucionalID = model.AsesorInstitucionalID,
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    ProgramaEducativoID = model.ProgramaEducativoID
                };
                _context.Add(asesorI);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", model.ProgramaEducativoID);
            return View(model);
        }

        // GET: AsesorInstitucionals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.AsesoresInstitucionales == null)
            {
                return NotFound();
            }

            var asesorInstitucional = await _context.AsesoresInstitucionales.FindAsync(id);
            if (asesorInstitucional == null)
            {
                return NotFound();
            }
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", asesorInstitucional.ProgramaEducativoID);
            return View(asesorInstitucional);
        }

        // POST: AsesorInstitucionals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AsesorInstitucionalID,Nombre,ApellidoP,ApellidoM,ProgramaEducativoID")] AsesorInstitucional asesorInstitucional)
        {
            if (id != asesorInstitucional.AsesorInstitucionalID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asesorInstitucional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsesorInstitucionalExists(asesorInstitucional.AsesorInstitucionalID))
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
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", asesorInstitucional.ProgramaEducativoID);
            return View(asesorInstitucional);
        }

        // GET: AsesorInstitucionals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AsesoresInstitucionales == null)
            {
                return NotFound();
            }

            var asesorInstitucional = await _context.AsesoresInstitucionales
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.AsesorInstitucionalID == id);
            if (asesorInstitucional == null)
            {
                return NotFound();
            }

            return View(asesorInstitucional);
        }

        // POST: AsesorInstitucionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.AsesoresInstitucionales == null)
            {
                return Problem("Entity set 'ProgramaDualContext.AsesoresInstitucionales'  is null.");
            }
            var asesorInstitucional = await _context.AsesoresInstitucionales.FindAsync(id);
            if (asesorInstitucional != null)
            {
                _context.AsesoresInstitucionales.Remove(asesorInstitucional);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsesorInstitucionalExists(string id)
        {
          return _context.AsesoresInstitucionales.Any(e => e.AsesorInstitucionalID == id);
        }
    }
}
