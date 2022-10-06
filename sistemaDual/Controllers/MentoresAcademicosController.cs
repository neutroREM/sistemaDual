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
    public class MentoresAcademicosController : Controller
    {
        private readonly ProgramaDualContext _context;

        public MentoresAcademicosController(ProgramaDualContext context)
        {
            _context = context;
        }

        // GET: MentorAcademicoes
        public async Task<IActionResult> Index()
        {
            var programaDualContext = _context.MentoresAcademicos.Include(m => m.ProgramaEducativo);
            return View(await programaDualContext.ToListAsync());
        }

        // GET: MentorAcademicoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.MentoresAcademicos == null)
            {
                return NotFound();
            }

            var mentorAcademico = await _context.MentoresAcademicos
                .Include(m => m.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.MentorAcademicoID == id);
            if (mentorAcademico == null)
            {
                return NotFound();
            }

            return View(mentorAcademico);
        }

        // GET: MentorAcademicoes/Create
        public IActionResult Create()
        {
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre");
            return View();
        }

        // POST: MentorAcademicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorAcademicoID,Nombre,ApellidoP,ApellidoM,ProgramaEducativoID")] MentorAcademicoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mentorA = new MentorAcademico()
                {
                    MentorAcademicoID = model.MentorAcademicoID,
                    Nombre = model.Nombre,
                    ApellidoP = model.ApellidoP,
                    ApellidoM = model.ApellidoM,
                    ProgramaEducativoID = model.ProgramaEducativoID
                };
                _context.Add(mentorA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", model.ProgramaEducativoID);
            return View(model);
        }

        // GET: MentorAcademicoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.MentoresAcademicos == null)
            {
                return NotFound();
            }

            var mentorAcademico = await _context.MentoresAcademicos.FindAsync(id);
            if (mentorAcademico == null)
            {
                return NotFound();
            }
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", mentorAcademico.ProgramaEducativoID);
            return View(mentorAcademico);
        }

        // POST: MentorAcademicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MentorAcademicoID,Nombre,ApellidoP,ApellidoM,ProgramaEducativoID")] MentorAcademico mentorAcademico)
        {
            if (id != mentorAcademico.MentorAcademicoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentorAcademico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorAcademicoExists(mentorAcademico.MentorAcademicoID))
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
            ViewData["ProgramaEducativoID"] = new SelectList(_context.ProgramasEducativos, "ID", "Nombre", mentorAcademico.ProgramaEducativoID);
            return View(mentorAcademico);
        }

        // GET: MentorAcademicoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.MentoresAcademicos == null)
            {
                return NotFound();
            }

            var mentorAcademico = await _context.MentoresAcademicos
                .Include(m => m.ProgramaEducativo)
                .FirstOrDefaultAsync(m => m.MentorAcademicoID == id);
            if (mentorAcademico == null)
            {
                return NotFound();
            }

            return View(mentorAcademico);
        }

        // POST: MentorAcademicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MentoresAcademicos == null)
            {
                return Problem("Entity set 'ProgramaDualContext.MentoresAcademicos'  is null.");
            }
            var mentorAcademico = await _context.MentoresAcademicos.FindAsync(id);
            if (mentorAcademico != null)
            {
                _context.MentoresAcademicos.Remove(mentorAcademico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorAcademicoExists(string id)
        {
          return _context.MentoresAcademicos.Any(e => e.MentorAcademicoID == id);
        }
    }
}
