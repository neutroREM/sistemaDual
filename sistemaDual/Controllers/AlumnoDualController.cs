using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistemaDual.Data;
using sistemaDual.Models;

namespace sistemaDual.Controllers
{
    public class AlumnoDualController : Controller
    {
        private readonly ProgramaDualContext _context;

        public AlumnoDualController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: AlumnoDual
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.AlumnosDuales.Include(a => a.BecaDual).Include(a => a.Domicilio).Include(a => a.ProgramaEducativo);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: AlumnoDual/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AlumnosDuales == null)
            {
                return NotFound();
            }

            var alumnoDual = await _context.AlumnosDuales
                .Include(a => a.BecaDual)
                .Include(a => a.Domicilio)
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnoDual == null)
            {
                return NotFound();
            }

            return View(alumnoDual);
        }

        // GET: AlumnoDual/Create
        public IActionResult Create()
        {
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "ID", "ID");
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "ID", "ID");
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "ID");
            return View();
        }

        // POST: AlumnoDual/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Curp,Matricula,Nombre,ApellidoP,ApellidoM,Telefono,Cuatrimestre,Tipo,Promedio,FechaRegistro,FechaIngreso,FechaReingreso,FechaEgreso,FechaContratado,DomicilioID,ProgramaEducativoID,BecaDualID")] AlumnoDual alumnoDual)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alumnoDual);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "ID", "ID", alumnoDual.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "ID", "ID", alumnoDual.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "ID", alumnoDual.ProgramaEducativoID);
            return View(alumnoDual);
        }

        // GET: AlumnoDual/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AlumnosDuales == null)
            {
                return NotFound();
            }

            var alumnoDual = await _context.AlumnosDuales.FindAsync(id);
            if (alumnoDual == null)
            {
                return NotFound();
            }
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "ID", "ID", alumnoDual.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "ID", "ID", alumnoDual.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "ID", alumnoDual.ProgramaEducativoID);
            return View(alumnoDual);
        }

        // POST: AlumnoDual/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Curp,Matricula,Nombre,ApellidoP,ApellidoM,Telefono,Cuatrimestre,Tipo,Promedio,FechaRegistro,FechaIngreso,FechaReingreso,FechaEgreso,FechaContratado,DomicilioID,ProgramaEducativoID,BecaDualID")] AlumnoDual alumnoDual)
        {
            if (id != alumnoDual.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumnoDual);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlumnoDualExists(alumnoDual.ID))
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
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "ID", "ID", alumnoDual.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "ID", "ID", alumnoDual.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "ID", alumnoDual.ProgramaEducativoID);
            return View(alumnoDual);
        }

        // GET: AlumnoDual/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AlumnosDuales == null)
            {
                return NotFound();
            }

            var alumnoDual = await _context.AlumnosDuales
                .Include(a => a.BecaDual)
                .Include(a => a.Domicilio)
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (alumnoDual == null)
            {
                return NotFound();
            }

            return View(alumnoDual);
        }

        // POST: AlumnoDual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AlumnosDuales == null)
            {
                return Problem("Entity set 'ProgramaDualContext.AlumnosDuales'  is null.");
            }
            var alumnoDual = await _context.AlumnosDuales.FindAsync(id);
            if (alumnoDual != null)
            {
                _context.AlumnosDuales.Remove(alumnoDual);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoDualExists(int id)
        {
          return _context.AlumnosDuales.Any(e => e.ID == id);
        }
    }
}
