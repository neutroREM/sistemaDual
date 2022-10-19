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
    public class AlumnosDualesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public AlumnosDualesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: AlumnosDuales
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.AlumnosDuales.Include(a => a.BecaDual).Include(a => a.Domicilio).Include(a => a.ProgramaEducativo);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: AlumnosDuales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.AlumnosDuales == null)
            {
                return NotFound();
            }

            var alumnoDual = await _context.AlumnosDuales
                .Include(a => a.BecaDual)
                .Include(a => a.Domicilio)
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.AlumnoDualID == id);
            if (alumnoDual == null)
            {
                return NotFound();
            }

            return View(alumnoDual);
        }

        // GET: AlumnosDuales/Create
        public IActionResult Create()
        {
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "BecaDUalID", "BecaDUalID");
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID");
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre");
            return View();
        }

        // POST: AlumnosDuales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlumnoDualID,Matricula,Nombre,ApellidoP,ApellidoM,Direccion,Colonia,Municipio,CodigoPostal,Telefono,Cuatrimestre,Tipo,Promedio,FechaRegistro")] AlumnoDualViewModel model)
        {
            if (ModelState.IsValid)
            {
                string dir = model.Direccion;
                string col = model.Colonia;
                string mun = model.Municipio;
                string cp = model.CodigoPostal;

                var domi = new Domicilio()
                {
                    Direccion = dir,
                    Colonia = col,
                    Municipio = mun,
                    CodigoPostal = cp
                };
                _context.Add(domi);
                await _context.SaveChangesAsync();

                var alumnoD = new AlumnoDual()
                {
                    AlumnoDualID = model.AlumnoDualID,
                    Matricula = model.Matricula,
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    Telefono = model.Telefono,
                    Cuatrimestre = model.Cuatrimestre,
                    Tipo = model.Tipo,
                    Promedio = model.Promedio,
                    FechaRegistro = model.FechaRegistro,
                    DomicilioID = domi.DomicilioID

                };
                _context.Add(alumnoD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "BecaDUalID", "BecaDUalID", model.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", model.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", model.ProgramaEducativoID);
            return View(model);
        }

        // GET: AlumnosDuales/Edit/5
        public async Task<IActionResult> Edit(string id)
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
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "BecaDUalID", "BecaDUalID", alumnoDual.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", alumnoDual.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", alumnoDual.ProgramaEducativoID);
            return View(alumnoDual);
        }

        // POST: AlumnosDuales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AlumnoDualID,Matricula,Nombre,ApellidoP,ApellidoM,Telefono,Cuatrimestre,Tipo,Promedio,FechaRegistro,FechaIngreso,FechaReingreso,FechaEgreso,FechaContratado,ProgramaEducativoID,BecaDualID,DomicilioID")] AlumnoDual alumnoDual)
        {
            if (id != alumnoDual.AlumnoDualID)
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
                    if (!AlumnoDualExists(alumnoDual.AlumnoDualID))
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
            ViewData["BecaDualID"] = new SelectList(_context.BecasDuales, "BecaDUalID", "BecaDUalID", alumnoDual.BecaDualID);
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", alumnoDual.DomicilioID);
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", alumnoDual.ProgramaEducativoID);
            return View(alumnoDual);
        }

        // GET: AlumnosDuales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.AlumnosDuales == null)
            {
                return NotFound();
            }

            var alumnoDual = await _context.AlumnosDuales
                .Include(a => a.BecaDual)
                .Include(a => a.Domicilio)
                .Include(a => a.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.AlumnoDualID == id);
            if (alumnoDual == null)
            {
                return NotFound();
            }

            return View(alumnoDual);
        }

        // POST: AlumnosDuales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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

        private bool AlumnoDualExists(string id)
        {
          return _context.AlumnosDuales.Any(e => e.AlumnoDualID == id);
        }
    }
}
