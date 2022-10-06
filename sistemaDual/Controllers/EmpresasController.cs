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
    public class EmpresasController : Controller
    {
        private readonly ProgramaDualContext _context;

        public EmpresasController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: Empresas
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.Empresas.Include(e => e.Domicilio);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: Empresas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Domicilio)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        public IActionResult Create()
        {
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID");
            return View();
        }

        // POST: Empresas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpresaID,RazonS,NombreC,SectorS,RepresentanteL,CorreoR,DomicilioID")] EmpresaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var empresa = new Empresa()
                {
                    EmpresaID = model.EmpresaID,
                    RazonS = model.RazonS,
                    NombreC = model.NombreC,
                    SectorS = model.SectorS,
                    RepresentanteL = model.RepresentanteL,
                    CorreoR = model.RepresentanteL,
                    DomicilioID = model.DomicilioID
                };
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", model.DomicilioID);
            return View(model);
        }

        // GET: Empresas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", empresa.DomicilioID);
            return View(empresa);
        }

        // POST: Empresas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpresaID,RazonS,NombreC,SectorS,RepresentanteL,CorreoR,DomicilioID")] Empresa empresa)
        {
            if (id != empresa.EmpresaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.EmpresaID))
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
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", empresa.DomicilioID);
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Empresas == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .Include(e => e.Domicilio)
                .FirstOrDefaultAsync(m => m.EmpresaID == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Empresas == null)
            {
                return Problem("Entity set 'ProgramaDualContext.Empresas'  is null.");
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa != null)
            {
                _context.Empresas.Remove(empresa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(string id)
        {
          return _context.Empresas.Any(e => e.EmpresaID == id);
        }
    }
}
