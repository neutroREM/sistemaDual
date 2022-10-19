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
    public class CatalagoProyectosController : Controller
    {
        private readonly ProgramaDualContext _context;

        public CatalagoProyectosController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: CatalagoProyectos
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.CatalagoProyectos.Include(c => c.AlumnoDual).Include(c => c.Empresa);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: CatalagoProyectos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CatalagoProyectos == null)
            {
                return NotFound();
            }

            var catalagoProyecto = await _context.CatalagoProyectos
                .Include(c => c.AlumnoDual)
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalagoProyecto == null)
            {
                return NotFound();
            }

            return View(catalagoProyecto);
        }

        // GET: CatalagoProyectos/Create
        public IActionResult Create()
        {
            ViewData["AlumnoDualID"] = new SelectList(_context.AlumnosDuales, "AlumnoDualID", "AlumnoDualID");
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID");
            return View();
        }

        // POST: CatalagoProyectos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Nombre,Etapa,AreaConocimiento,NumHoras,FechaInicio,FechaTermino,Estatus,FechaCambioEstatus,AlumnoDualID,EmpresaID")] CatalagoProyectoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var catalagoP = new CatalagoProyecto()
                {
                    ID = model.ID,
                    Nombre = model.Nombre,
                    Etapa = model.Etapa,
                    AreaConocimiento = model.AreaConocimiento,
                    NumHoras = model.NumHoras,
                    FechaInicio = model.FechaInicio,
                    FechaTermino = model.FechaTermino,
                    
                    FechaCambioEstatus = model.FechaCambioEstatus,
                    AlumnoDualID = model.AlumnoDualID,
                    EmpresaID = model.EmpresaID
                };
                _context.Add(catalagoP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlumnoDualID"] = new SelectList(_context.AlumnosDuales, "AlumnoDualID", "AlumnoDualID", model.AlumnoDualID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", model.EmpresaID);
            return View(model);
        }

        // GET: CatalagoProyectos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CatalagoProyectos == null)
            {
                return NotFound();
            }

            var catalagoProyecto = await _context.CatalagoProyectos.FindAsync(id);
            if (catalagoProyecto == null)
            {
                return NotFound();
            }
            ViewData["AlumnoDualID"] = new SelectList(_context.AlumnosDuales, "AlumnoDualID", "AlumnoDualID", catalagoProyecto.AlumnoDualID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", catalagoProyecto.EmpresaID);
            return View(catalagoProyecto);
        }

        // POST: CatalagoProyectos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Nombre,Etapa,AreaConocimiento,NumHoras,FechaInicio,FechaTermino,Estatus,FechaCambioEstatus,AlumnoDualID,EmpresaID")] CatalagoProyecto catalagoProyecto)
        {
            if (id != catalagoProyecto.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(catalagoProyecto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CatalagoProyectoExists(catalagoProyecto.ID))
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
            ViewData["AlumnoDualID"] = new SelectList(_context.AlumnosDuales, "AlumnoDualID", "AlumnoDualID", catalagoProyecto.AlumnoDualID);
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", catalagoProyecto.EmpresaID);
            return View(catalagoProyecto);
        }

        // GET: CatalagoProyectos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CatalagoProyectos == null)
            {
                return NotFound();
            }

            var catalagoProyecto = await _context.CatalagoProyectos
                .Include(c => c.AlumnoDual)
                .Include(c => c.Empresa)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (catalagoProyecto == null)
            {
                return NotFound();
            }

            return View(catalagoProyecto);
        }

        // POST: CatalagoProyectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CatalagoProyectos == null)
            {
                return Problem("Entity set 'ProgramaDualContext.CatalagoProyectos'  is null.");
            }
            var catalagoProyecto = await _context.CatalagoProyectos.FindAsync(id);
            if (catalagoProyecto != null)
            {
                _context.CatalagoProyectos.Remove(catalagoProyecto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CatalagoProyectoExists(int id)
        {
          return _context.CatalagoProyectos.Any(e => e.ID == id);
        }
    }
}
