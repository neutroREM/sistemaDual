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
    public class MentoresEmpresarialesController : Controller
    {
        private readonly ProgramaDualContext _context;

        public MentoresEmpresarialesController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: MentoresEmpresariales
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.MentoresEmpresariales.Include(m => m.Empresa);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: MentoresEmpresariales/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MentoresEmpresariales == null)
            {
                return NotFound();
            }

            var mentorEmpresarial = await _context.MentoresEmpresariales
                .Include(m => m.Empresa)
                .FirstOrDefaultAsync(m => m.MentorEmpresarialID == id);
            if (mentorEmpresarial == null)
            {
                return NotFound();
            }

            return View(mentorEmpresarial);
        }

        // GET: MentoresEmpresariales/Create
        public IActionResult Create()
        {
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID");
            return View();
        }

        // POST: MentoresEmpresariales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorEmpresarialID,ApellidoP,ApellidoM,Correo,Telefono,Cargo,EmpresaID")] MentorEmpresarialViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mentorE = new MentorEmpresarial()
                {
                    MentorEmpresarialID = model.MentorEmpresarialID,
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    Correo = model.Correo,
                    Telefono = model.Telefono,
                    Cargo = model.Cargo,
                    EmpresaID = model.EmpresaID
                };
                _context.Add(mentorE);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", model.EmpresaID);
            return View(model);
        }

        // GET: MentoresEmpresariales/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MentoresEmpresariales == null)
            {
                return NotFound();
            }

            var mentorEmpresarial = await _context.MentoresEmpresariales.FindAsync(id);
            if (mentorEmpresarial == null)
            {
                return NotFound();
            }
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", mentorEmpresarial.EmpresaID);
            return View(mentorEmpresarial);
        }

        // POST: MentoresEmpresariales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MentorEmpresarialID,ApellidoP,ApellidoM,Correo,Telefono,Cargo,EmpresaID")] MentorEmpresarial mentorEmpresarial)
        {
            if (id != mentorEmpresarial.MentorEmpresarialID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentorEmpresarial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorEmpresarialExists(mentorEmpresarial.MentorEmpresarialID))
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
            ViewData["EmpresaID"] = new SelectList(_context.Empresas, "EmpresaID", "EmpresaID", mentorEmpresarial.EmpresaID);
            return View(mentorEmpresarial);
        }

        // GET: MentoresEmpresariales/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MentoresEmpresariales == null)
            {
                return NotFound();
            }

            var mentorEmpresarial = await _context.MentoresEmpresariales
                .Include(m => m.Empresa)
                .FirstOrDefaultAsync(m => m.MentorEmpresarialID == id);
            if (mentorEmpresarial == null)
            {
                return NotFound();
            }

            return View(mentorEmpresarial);
        }

        // POST: MentoresEmpresariales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MentoresEmpresariales == null)
            {
                return Problem("Entity set 'ProgramaDualContext.MentoresEmpresariales'  is null.");
            }
            var mentorEmpresarial = await _context.MentoresEmpresariales.FindAsync(id);
            if (mentorEmpresarial != null)
            {
                _context.MentoresEmpresariales.Remove(mentorEmpresarial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorEmpresarialExists(string id)
        {
          return _context.MentoresEmpresariales.Any(e => e.MentorEmpresarialID == id);
        }
    }
}
