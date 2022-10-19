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
    public class UniversidadesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public UniversidadesController(ProgramaDualContext context)
        {
            _context = context;
        }


        // GET: Universidads
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.Universidades.Include(u => u.Domicilio);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: Universidads/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades
                .Include(u => u.Domicilio)
                .FirstOrDefaultAsync(m => m.UniversidadID == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // GET: Universidads/Create
        public IActionResult Create()
        {
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID");
            return View();
        }

        // POST: Universidads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UniversidadID,NombreU,Direccion,Colonia,Municipio,CodigoPostal,NombrePE,Version")] UniversidadViewModel model)
        {
            if (ModelState.IsValid)
            {
                string idU = model.UniversidadID;
                string nomU = model.NombreU;
                

                string dir = model.Direccion;
                string col = model.Colonia;
                string mun = model.Municipio;
                string cp = model.CodigoPostal;

                string nomPE = model.NombrePE;
                string ver = model.Version;

                /*
                string idR = model.ResposableID;
                string nomR = model.NombreRI;
                string ap = model.ApellidoP;
                string am = model.ApellidoM;
                string correo = model.Correo;
                int tel = model.Telefono;
                string cargo = model.Cargo;
                */
                var domi = new Domicilio()
                {
                    Direccion = dir,
                    Colonia = col,
                    Municipio = mun,
                    CodigoPostal = cp
                };
                _context.Add(domi);
                await _context.SaveChangesAsync();


                var uni = new Universidad()
                {
                    UniversidadID = idU,
                    NombreU = nomU,
                    DomicilioID = domi.DomicilioID
                };
                _context.Add(uni);
                await _context.SaveChangesAsync();

                var pe = new ProgramaEducativo()
                {
                    Nombre = nomPE,
                    Version = ver,
                    UniversidadID = idU
                };
                _context.Add(pe);
                await _context.SaveChangesAsync();
                /*
                var ri = new ResponsableInstitucional()
                {
                    ResponsableInstitucionalID = idR,
                    Nombre = nomR,
                    ApellidoM = am,
                    ApellidoP = ap,
                    Correo = correo,
                    Telefono = tel,
                    Cargo = cargo,
                    UniversidadID = idU
                };
                _context.Add(ri);
                await _context.SaveChangesAsync();
                */
                return RedirectToAction(nameof(Index));
            }
            
            return View(model);
        }

        // GET: Universidads/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad == null)
            {
                return NotFound();
            }
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", universidad.DomicilioID);
            return View(universidad);
        }

        // POST: Universidads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UniversidadID,NombreU,DomicilioID")] Universidad universidad)
        {
            if (id != universidad.UniversidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(universidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UniversidadExists(universidad.UniversidadID))
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
            ViewData["DomicilioID"] = new SelectList(_context.Domicilios, "DomicilioID", "DomicilioID", universidad.DomicilioID);
            return View(universidad);
        }

        // GET: Universidads/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Universidades == null)
            {
                return NotFound();
            }

            var universidad = await _context.Universidades
                .Include(u => u.Domicilio)
                .FirstOrDefaultAsync(m => m.UniversidadID == id);
            if (universidad == null)
            {
                return NotFound();
            }

            return View(universidad);
        }

        // POST: Universidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Universidades == null)
            {
                return Problem("Entity set 'ProgramaDualContext.Universidades'  is null.");
            }
            var universidad = await _context.Universidades.FindAsync(id);
            if (universidad != null)
            {
                _context.Universidades.Remove(universidad);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniversidadExists(string id)
        {
          return _context.Universidades.Any(e => e.UniversidadID == id);
        }
    }
}
